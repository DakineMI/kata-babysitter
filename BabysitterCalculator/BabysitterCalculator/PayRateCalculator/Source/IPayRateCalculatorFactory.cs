namespace BabysitterCalculator.PayRateCalculator.Source
{
    public interface IPayRateCalculatorFactory
    {
        IPayRateCalculator GetPayRateCalculator(WorkHourType workHourType);
    }
}