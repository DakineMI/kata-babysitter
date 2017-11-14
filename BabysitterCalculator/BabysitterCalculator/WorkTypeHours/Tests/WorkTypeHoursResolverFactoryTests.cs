namespace BabysitterCalculator.WorkTypeHours.Tests
{
    using Source;
    using System.Collections.Generic;
    using FluentAssertions;
    using Xunit;

    public class WorkTypeHoursResolverFactoryTests
    {
        WorkTypeHoursResolverFactory factory;

        public WorkTypeHoursResolverFactoryTests()
        {
            var WorkTypeHoursResolvers = new Dictionary<WorkTypeHourResolverType, IWorkTypeHoursResolver>
            {
                {WorkTypeHourResolverType.Default, new DefaultWorkTypeHoursResolver()}
            };

            factory = new WorkTypeHoursResolverFactory(WorkTypeHoursResolvers);
        }

        [Theory]
        [InlineData(WorkTypeHourResolverType.Default, "DefaultWorkTypeHoursResolver")]
        public void ReturnsTheCorrectInstanceTypeOfIPayRateCalculatorForTheWorkHourType(WorkTypeHourResolverType workTypeHourResolverType, string expectedResult)
        {
            var workTypeHourResolver = factory.GetWorkTypeHoursResolver(workTypeHourResolverType);
            workTypeHourResolver.GetType().Name.Should().Be(expectedResult, $"WorkHourType {workTypeHourResolverType} should return {expectedResult}.");
        }
    }
}
