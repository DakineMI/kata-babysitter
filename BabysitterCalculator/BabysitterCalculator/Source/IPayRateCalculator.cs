using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BabysitterCalculator.Source
{
    interface IPayRateCalculator
    {
        decimal CalculatePay(int hoursWorked);
    }
}
