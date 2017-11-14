namespace BabysitterCalculator.PayRateCalculator.Source
{
    public interface IPayRateCalculator
    {
        decimal CalculatePay(int hoursWorked);
    }
}
