namespace BabysitterCalculator.PayRateCalculator.Tests
{
    using Source;
    using Xunit;
    using FluentAssertions;

    public class BedTimePayRateCalculatorTests
    {
        IPayRateCalculator Calculator;

        public BedTimePayRateCalculatorTests()
        {
            Calculator = new BedTimePayRateCalculator();
        }

        [Theory]
        [InlineData(3, 24.0)]
        [InlineData(4, 32.0)]
        [InlineData(5, 40.0)]
        public void BedTimePayRateCalculatorReturnsTheCorrectPayForTheyHoursEntered(int hoursWorked, decimal expectedPay )
        {
            (Calculator.CalculatePay(hoursWorked)).Should().Be(expectedPay, $"The hours worked multiplied by the bed time pay rate of ${Constants.BEDTIME_PAY_RATE} should by ${expectedPay}");
        }
    }
}
