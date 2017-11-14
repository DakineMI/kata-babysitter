namespace BabysitterCalculator.WorkTypeHours.Source
{
    using System;
    using System.Collections.Generic;

    public interface IWorkTypeHoursResolver
    {
        Dictionary<WorkHourType, int> GetTheNumberOfHoursByWorkType(DateTime startTime, DateTime endTime, DateTime bedTime);
    }
}
