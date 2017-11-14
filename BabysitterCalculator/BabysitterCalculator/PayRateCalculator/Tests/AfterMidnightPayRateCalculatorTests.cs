namespace BabysitterCalculator.PayRateCalculator.Tests
{
    using FluentAssertions;
    using Source;
    using Xunit;

    public class AfterMidnightPayRateCalculatorTests
    {
        IPayRateCalculator Calculator;

        public AfterMidnightPayRateCalculatorTests()
        {
            Calculator = new AfterMidnightPayRateCalculator();
        }

        [Theory]
        [InlineData(3, 48.0)]
        [InlineData(4, 64.0)]
        [InlineData(5, 80.0)]
        public void AfterMidnightPayRateCalculatorReturnsTheCorrectPayForTheyHoursEntered(int hoursWorked, decimal expectedPay )
        {
            (Calculator.CalculatePay(hoursWorked)).Should().Be(expectedPay, $"The hours worked multiplied by the after midnight pay rate of ${Constants.AFTER_MIDNIGHT_PAY_RATE} should by ${expectedPay}");
        }
    }
}
