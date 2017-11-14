namespace BabysitterCalculator
{
    using BabysitterCalculator.PayRateCalculator.Source;
    using BabysitterCalculator.WorkTypeHours.Source;
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using Xunit;

    public class PayCalculatorTests
    {
        private readonly PayCalculator payCalculator;

        public PayCalculatorTests()
        {
            var WorkTypeHoursResolvers = new Dictionary<WorkTypeHourResolverType, IWorkTypeHoursResolver>
            {
                {WorkTypeHourResolverType.Default, new DefaultWorkTypeHoursResolver()}
            };

            var workTypeHoursFactory = new WorkTypeHoursResolverFactory(WorkTypeHoursResolvers);

            var PayRateCalculators = new Dictionary<WorkHourType, IPayRateCalculator>
            {
                {WorkHourType.Default, new DefaultPayRateCalculator()},
                {WorkHourType.BedTime, new BedTimePayRateCalculator()},
                {WorkHourType.AfterMidnight, new AfterMidnightPayRateCalculator()}
            };

            var payRateFactory = new PayRateCalculatorFactory(PayRateCalculators);

            payCalculator = new PayCalculator(workTypeHoursFactory, payRateFactory);
        }

        [Theory]
        [InlineData("11/14/2017 05:00:00 PM", "11/15/2017 04:00:00 AM", "11/14/2017 09:00:00 PM",136.0)]
        [InlineData("11/14/2017 05:15:00 PM", "11/14/2017 11:43:00 PM", "11/14/2017 09:00:00 PM", 72.0)]
        [InlineData("11/14/2017 05:15:00 PM", "11/14/2017 11:43:00 PM", "11/14/2017 04:00:00 PM", 84.0)]
        [InlineData("11/14/2017 05:00:00 PM", "11/14/2017 11:43:00 PM", "11/14/2017 05:00:00 PM", 56.0)]
        [InlineData("11/15/2017 0:00:00 AM", "11/15/2017 3:43:00 AM", "11/14/2017 05:00:00 PM", 64.0)]
        [InlineData("11/15/2017 0:00:00 AM", "11/15/2017 3:43:00 AM", "11/15/2017 01:00:00 AM", 64.0)]
        public void ReturnsTheCorrectPayForTheHoursEntered(string startTime, string endTime, string bedTime, decimal expectedPay)
        {
            var start = DateTime.Parse(startTime);
            var stop = DateTime.Parse(endTime);
            var bed = DateTime.Parse(bedTime);

            payCalculator.CalculateNightlyCharge(start, stop, bed).Should().Be(expectedPay);
        }

        [Fact]
        public void ReturnsAnErrorWhenTheStartTimeIsOutOfRange()
        {
            var start = DateTime.Parse("11/14/2017 6:00:00 AM");
            var stop = DateTime.Parse("11/15/2017 3:43:00 AM");
            var bed = DateTime.Parse("11/14/2017 01:00:00 AM");

            Action act = () => payCalculator.CalculateNightlyCharge(start, stop, bed);

            act.ShouldThrow<ArgumentOutOfRangeException>()
                 .WithMessage("Specified argument was out of the range of valid values.\r\nParameter name: The start time must be between 5 PM and 4 AM");
        }

        [Fact]
        public void ReturnsAnErrorWhenTheEndTimeIsOutOfRange()
        {
            var start = DateTime.Parse("11/14/2017 6:00:00 PM");
            var stop = DateTime.Parse("11/15/2017 4:43:00 AM");
            var bed = DateTime.Parse("11/14/2017 04:15:00 AM");

            Action act = () => payCalculator.CalculateNightlyCharge(start, stop, bed);

            act.ShouldThrow<ArgumentOutOfRangeException>()
                 .WithMessage("Specified argument was out of the range of valid values.\r\nParameter name: The end time must be between 5 PM and 4 AM");
        }

        [Fact]
        public void ReturnsAnErrorWhenTheEndTimeIsLessThanTheStartTime()
        {
            var start = DateTime.Parse("11/15/2017 11:00:00 PM");
            var stop = DateTime.Parse("11/15/2017 3:43:00 AM");
            var bed = DateTime.Parse("11/15/2017 05:15:00 PM");

            Action act = () => payCalculator.CalculateNightlyCharge(start, stop, bed);

            act.ShouldThrow<ArgumentOutOfRangeException>()
                 .WithMessage("Specified argument was out of the range of valid values.\r\nParameter name: The end time must after the start time");
        }
    }
}
