namespace BabysitterCalculator.Source
{
    using System;

    public class AfterMidnightPayRateCalculator : IPayRateCalculator
    {
        public decimal CalculatePay(int hoursWorked)
        {
            return Math.Round(hoursWorked * Constants.AFTER_MIDNIGHT_PAY_RATE, 2);
        }
    }
}