namespace BabysitterCalculator.WorkTypeHours.Source
{
    using System;
    using System.Collections.Generic;

    public class WorkTypeHoursResolverFactory : IWorkTypeHoursResolverFactory
    {
        private readonly Dictionary<WorkTypeHourResolverType, IWorkTypeHoursResolver> WorkTypeHoursResolvers;

        public WorkTypeHoursResolverFactory(Dictionary<WorkTypeHourResolverType, IWorkTypeHoursResolver> workTypeHoursResolvers)
        {
            WorkTypeHoursResolvers = workTypeHoursResolvers;
        }

        public IWorkTypeHoursResolver GetWorkTypeHoursResolver(WorkTypeHourResolverType workHourTypeResolver)
        {
            IWorkTypeHoursResolver WorkTypeHoursResolver;

            if (!WorkTypeHoursResolvers.TryGetValue(workHourTypeResolver, out WorkTypeHoursResolver))
            {
                throw new NotImplementedException($"There is not implementation of IWorkTypeHoursResolver for {workHourTypeResolver.ToString()}.");
            }

            return WorkTypeHoursResolver;
        }
    }
}
