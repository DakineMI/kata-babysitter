namespace BabysitterCalculator.PayRateCalculator.Tests
{
    using Source;
    using System.Collections.Generic;
    using FluentAssertions;
    using Xunit;

    public class PayRateCalculatorFactoryTests
    {
        PayRateCalculatorFactory factory;

        public PayRateCalculatorFactoryTests()
        {
            var PayRateCalculators = new Dictionary<WorkHourType, IPayRateCalculator>
            {
                {WorkHourType.Default, new DefaultPayRateCalculator()},
                {WorkHourType.BedTime, new BedTimePayRateCalculator()},
                {WorkHourType.AfterMidnight, new AfterMidnightPayRateCalculator()}
            };

            factory = new PayRateCalculatorFactory(PayRateCalculators);
        }

        [Theory]
        [InlineData(WorkHourType.Default, "DefaultPayRateCalculator")]
        [InlineData(WorkHourType.BedTime, "BedTimePayRateCalculator")]
        [InlineData(WorkHourType.AfterMidnight, "AfterMidnightPayRateCalculator")]
        public void ReturnsTheCorrectInstanceTypeOfIPayRateCalculatorForTheWorkHourType(WorkHourType workHourType, string expectedResult)
        {
            var payRateCalculator = factory.GetPayRateCalculator(workHourType);
            payRateCalculator.GetType().Name.Should().Be(expectedResult, $"WorkHourType {workHourType} should return {expectedResult}.");
        }
    }
}
