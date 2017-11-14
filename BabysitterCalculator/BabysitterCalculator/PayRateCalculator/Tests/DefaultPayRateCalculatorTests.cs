namespace BabysitterCalculator.PayRateCalculator.Tests
{
    using Source;
    using Xunit;
    using FluentAssertions;

    public class DefaultPayRateCalculatorTests
    {
        IPayRateCalculator Calculator;

        public DefaultPayRateCalculatorTests()
        {
            Calculator = new DefaultPayRateCalculator();
        }

        [Theory]
        [InlineData(3, 36.0)]
        [InlineData(4, 48.0)]
        [InlineData(5, 60.0)]
        public void DefaultPayRateCalculatorReturnsTheCorrectPayForTheyHoursEntered(int hoursWorked, decimal expectedPay )
        {
            (Calculator.CalculatePay(hoursWorked)).Should().Be(expectedPay, $"The hours worked multiplied by the default pay rate of ${Constants.DEFAULT_PAY_RATE} should by ${expectedPay}");
        }
    }
}
