namespace BabysitterCalculator.PayRateCalculator.Source
{
    using System;

    public class DefaultPayRateCalculator : IPayRateCalculator
    {
        public decimal CalculatePay(int hoursWorked)
        {
            return Math.Round(hoursWorked * Constants.DEFAULT_PAY_RATE, 2);
        }
    }
}
