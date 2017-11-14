using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BabysitterCalculator.Source
{
    public class DefaultPayRateCalculator : IPayRateCalculator
    {
        public decimal CalculatePay(int hoursWorked)
        {
            return Math.Round(hoursWorked * Constants.DEFAULT_PAY_RATE, 2);
        }
    }
}
