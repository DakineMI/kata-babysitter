namespace BabysitterCalculator.WorkTypeHours.Source
{
    public interface IWorkTypeHoursResolverFactory
    {
        IWorkTypeHoursResolver GetWorkTypeHoursResolver(WorkTypeHourResolverType workTypeHourResolver);
    }
}