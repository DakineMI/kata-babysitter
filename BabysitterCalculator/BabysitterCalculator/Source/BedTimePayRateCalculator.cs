namespace BabysitterCalculator.Source
{
    using System;
    
    class BedTimePayRateCalculator : IPayRateCalculator
    {
        public decimal CalculatePay(int hoursWorked)
        {
            return Math.Round(hoursWorked * Constants.BEDTIME_PAY_RATE, 2);
        }
    }
}
