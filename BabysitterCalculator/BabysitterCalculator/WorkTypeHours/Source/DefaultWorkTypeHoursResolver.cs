namespace BabysitterCalculator.WorkTypeHours.Source
{
    using System;
    using System.Collections.Generic;
    public class DefaultWorkTypeHoursResolver : IWorkTypeHoursResolver
    {
        public Dictionary<WorkHourType, int> GetTheNumberOfHoursByWorkType(DateTime startTime, DateTime endTime, DateTime bedTime)
        {
            if ((endTime - startTime).TotalSeconds < 0)
                throw new ArgumentOutOfRangeException($"The end time must after the start time");

            var start = new DateTime(startTime.Year, startTime.Month, startTime.Day, startTime.Hour, 0, 0);
            var stop = new DateTime(endTime.Year, endTime.Month, endTime.Day, endTime.Hour, 0, 0);
            if (endTime.Minute > 0 || endTime.Second > 0)
                stop = stop.AddHours(1);
            var bed = new DateTime(bedTime.Year, bedTime.Month, bedTime.Day, bedTime.Hour, 0, 0);
            if (bedTime.Minute > 0 || bedTime.Second > 0)
                bed = bed.AddHours(1);
            var midnight = new DateTime(stop.Year, stop.Month, stop.Day, 0, 0, 0);
            if (stop.Hour > 17)
                midnight = midnight.AddDays(1);

            if (start.Hour < 17 && start.Hour > 4)
                throw new ArgumentOutOfRangeException($"The start time must be between 5 PM and 4 AM");
            if (stop.Hour < 17 && stop.Hour > 4)
                throw new ArgumentOutOfRangeException($"The end time must be between 5 PM and 4 AM");
            
            Dictionary<WorkHourType, int> WorkTypeHours = new Dictionary<WorkHourType, int>();

            int bedTimeHours = 0;
            int defaultHours = 0;
            int afterMidnightHours = 0;

            //If the start time is after midnight, there will only be after midnight hours
            if(start >= midnight)
            {
                if (stop == start)
                    afterMidnightHours = 1;
                else if (stop > start)
                    afterMidnightHours = (stop - start).Hours;
            }            
            else if (stop <= midnight) //Start and end times are before midnight
            {
                if (bed >= start && bed < stop)
                    bedTimeHours = (stop - bed).Hours;
                defaultHours = (stop - start).Hours - bedTimeHours;
            }
            else
            {
                if (bed >= start && bed < midnight)
                    bedTimeHours = (midnight - bed).Hours;
                defaultHours = (midnight - start).Hours - bedTimeHours;
                afterMidnightHours = (stop - midnight).Hours;
            }

            WorkTypeHours.Add(WorkHourType.Default, defaultHours);
            WorkTypeHours.Add(WorkHourType.BedTime, bedTimeHours);
            WorkTypeHours.Add(WorkHourType.AfterMidnight, afterMidnightHours);

            return WorkTypeHours;
        }
    }
}
