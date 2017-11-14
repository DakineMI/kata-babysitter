namespace BabysitterCalculator
{
    using BabysitterCalculator.PayRateCalculator.Source;
    using BabysitterCalculator.WorkTypeHours.Source;
    using System;

    public class PayCalculator
    {
        private readonly IWorkTypeHoursResolverFactory WorkTypeResolverFactory;
        private readonly IPayRateCalculatorFactory PayRateCalculatorFactory;

        public PayCalculator(IWorkTypeHoursResolverFactory workTypeResolverFactory, IPayRateCalculatorFactory payRateCalculatorFactory)
        {
            WorkTypeResolverFactory = workTypeResolverFactory;
            PayRateCalculatorFactory = payRateCalculatorFactory;
        }

        public decimal CalculateNightlyCharge(DateTime startTime, DateTime endTime, DateTime bedTime)
        {
            var workTypeHours = WorkTypeResolverFactory.GetWorkTypeHoursResolver(WorkTypeHourResolverType.Default).GetTheNumberOfHoursByWorkType(startTime, endTime, bedTime);
            decimal pay = 0;
            foreach (var item in workTypeHours)
            {
                pay += PayRateCalculatorFactory.GetPayRateCalculator(item.Key).CalculatePay(item.Value);
            }

            return pay;
        }
    }
}
