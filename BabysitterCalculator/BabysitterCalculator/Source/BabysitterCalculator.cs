using System;

namespace BabysitterCalculator.Source
{
    public class BabysitterCalculator
    {
        public BabysitterCalculator()
        {
        }

        public decimal CalculatePay(int hoursWorked, decimal payRate)
        {
            return hoursWorked * payRate;
        }
    }
}
