namespace BabysitterCalculator.PayRateCalculator.Source
{
    using System;
    using System.Collections.Generic;

    public class PayRateCalculatorFactory : IPayRateCalculatorFactory
    {
        private readonly Dictionary<WorkHourType, IPayRateCalculator> PayRateCalculators;

        public PayRateCalculatorFactory(Dictionary<WorkHourType, IPayRateCalculator> payRateCalculators)
        {
            PayRateCalculators = payRateCalculators;
        }

        public IPayRateCalculator GetPayRateCalculator(WorkHourType workHourType)
        {
            IPayRateCalculator calculator;

            if (!PayRateCalculators.TryGetValue(workHourType, out calculator))
            {
                throw new NotImplementedException($"There is not implementation of IPayRateCalculator for {workHourType.ToString()}.");
            }

            return calculator;
        }
    }
}
