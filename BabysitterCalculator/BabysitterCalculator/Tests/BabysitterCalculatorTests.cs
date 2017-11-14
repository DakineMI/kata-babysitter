namespace BabysitterCalculator.Tests
{
    using Source;
    using Xunit;
    using System;
    using FluentAssertions;

    public class BabysitterCalculatorTests
    {
        BabysitterCalculator babysitterCalculator;

        public BabysitterCalculatorTests()
        {
            babysitterCalculator = new BabysitterCalculator();
        }

        [Theory]
        [InlineData(3, 12, 36)]
        [InlineData(4, 8, 32)]
        [InlineData(5, 16, 80)]
        public void CalculatePay(int hoursWorked, decimal payRate, decimal expectedResult)
        {
            (babysitterCalculator.CalculatePay(hoursWorked, payRate)).Should().Be(expectedResult);
        }
    }
}
