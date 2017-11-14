namespace BabysitterCalculator.WorkType.Tests
{
    using FluentAssertions;
    using Source;
    using System;
    using Xunit;

    public class WorkTypeHoursTests
    {

        [Fact]
        public void ReturnsCorrectWorkTypeHoursWithBedTimeBeforeStartTimeAndEndTimeAfterMidnight()
        {
            DateTime startTime = DateTime.Now.Date.AddHours(-5).AddMinutes(-10);
            DateTime endTime = DateTime.Now.Date.AddMinutes(2);
            DateTime bedTime = DateTime.Now.Date.AddHours(-7);

            var x = new WorkTypeHours();

            var result = x.GetTheNumberOfHoursByWorkType(startTime, endTime, bedTime);
            result[WorkHourType.Default].Should().Be(6, "The default billable time is from 6 till midnight");
            result[WorkHourType.BedTime].Should().Be(0, "The bed time billable time is before the start time");
            result[WorkHourType.AfterMidnight].Should().Be(1, "The after midnight billable time is from midnight till 1");
        }

        [Fact]
        public void ReturnsCorrectWorkTypeHoursWithBedTimeAfterStartTimeAndEndTimeAfterMidnight()
        {
            DateTime startTime = DateTime.Now.Date.AddHours(-5).AddMinutes(-10);
            DateTime endTime = DateTime.Now.Date.AddMinutes(2);
            DateTime bedTime = DateTime.Now.Date.AddHours(-2);

            var x = new WorkTypeHours();

            var result = x.GetTheNumberOfHoursByWorkType(startTime, endTime, bedTime);
            result[WorkHourType.Default].Should().Be(4, "The default billable time is from 6 till 10");
            result[WorkHourType.BedTime].Should().Be(2, "The bed time billable time is from 10 till midnight");
            result[WorkHourType.AfterMidnight].Should().Be(1, "The after midnight billable time is from midnight till 1");
        }

        [Fact]
        public void ReturnsCorrectWorkTypeHoursWithBedTimeAfterStartTimeAndEndTimeBeforeMidnight()
        {
            DateTime startTime = DateTime.Now.Date.AddHours(-5).AddMinutes(-10);
            DateTime endTime = DateTime.Now.Date.AddMinutes(-2);
            DateTime bedTime = DateTime.Now.Date.AddHours(-2);

            var x = new WorkTypeHours();

            var result = x.GetTheNumberOfHoursByWorkType(startTime, endTime, bedTime);
            result[WorkHourType.Default].Should().Be(4, "The default billable time is from 6 till 10");
            result[WorkHourType.BedTime].Should().Be(2, "The bed time billable time is from 10 till midnight");
            result[WorkHourType.AfterMidnight].Should().Be(0, "The end time is before midnight");
        }

        [Fact]
        public void ReturnsCorrectWorkTypeHoursWithBedTimeBeforeStartTimeAndEndTimeBeforeMidnight()
        {
            DateTime startTime = DateTime.Now.Date.AddHours(-5).AddMinutes(-10);
            DateTime endTime = DateTime.Now.Date.AddMinutes(-2);
            DateTime bedTime = DateTime.Now.Date.AddHours(-7);

            var x = new WorkTypeHours();

            var result = x.GetTheNumberOfHoursByWorkType(startTime, endTime, bedTime);
            result[WorkHourType.Default].Should().Be(6, "The default billable time is from 6 till midnight");
            result[WorkHourType.BedTime].Should().Be(0, "The bed time billable time is before the start time");
            result[WorkHourType.AfterMidnight].Should().Be(0, "The end time is before midnight");
        }

        [Fact]
        public void ReturnsCorrectWorkTypeHoursWithBedTimeAfterTheEndTimeAndEndTimeBeforeMidnight()
        {
            DateTime startTime = DateTime.Now.Date.AddHours(-5).AddMinutes(-10);
            DateTime endTime = DateTime.Now.Date.AddMinutes(-5);
            DateTime bedTime = DateTime.Now.Date.AddMinutes(-2);

            var x = new WorkTypeHours();

            var result = x.GetTheNumberOfHoursByWorkType(startTime, endTime, bedTime);
            result[WorkHourType.Default].Should().Be(6, "The default billable time is from 6 till midnight");
            result[WorkHourType.BedTime].Should().Be(0, "The bed time billable time is after the end time");
            result[WorkHourType.AfterMidnight].Should().Be(0, "The end time is before midnight");
        }

        [Fact]
        public void ReturnsCorrectWorkTypeHoursWithBedTimeAndEndTimeAfterMidnight()
        {
            DateTime startTime = DateTime.Now.Date.AddHours(-5).AddMinutes(-10);
            DateTime endTime = DateTime.Now.Date.AddHours(4);
            DateTime bedTime = DateTime.Now.Date.AddHours(2);

            var x = new WorkTypeHours();

            var result = x.GetTheNumberOfHoursByWorkType(startTime, endTime, bedTime);
            result[WorkHourType.Default].Should().Be(6, "The default billable time is from 6 till midnight");
            result[WorkHourType.BedTime].Should().Be(0, "The bed time billable time is after midnight");
            result[WorkHourType.AfterMidnight].Should().Be(4, "The after midnight billable time is from midnight till 4");
        }

        [Fact]
        public void ReturnsCorrectWorkTypeHoursWithStartTimeAndEndTimeAfterMidnight()
        {
            DateTime startTime = DateTime.Now.Date.AddHours(1);
            DateTime endTime = DateTime.Now.Date.AddHours(4);
            DateTime bedTime = DateTime.Now.Date.AddHours(2);

            var x = new WorkTypeHours();

            var result = x.GetTheNumberOfHoursByWorkType(startTime, endTime, bedTime);
            result[WorkHourType.Default].Should().Be(0, "The default billable time is after midnight");
            result[WorkHourType.BedTime].Should().Be(0, "The bed time billable time is after midnight");
            result[WorkHourType.AfterMidnight].Should().Be(3, "The after midnight billable time is from 1 till 4");
        }

        [Fact]
        public void ReturnsCorrectWorkTypeHoursWithBedTimeEqualToStartTimeAndEndTimeAfterMidnight()
        {
            DateTime startTime = DateTime.Now.Date.AddHours(-6);
            DateTime endTime = DateTime.Now.Date.AddHours(2);
            DateTime bedTime = DateTime.Now.Date.AddHours(-6);

            var x = new WorkTypeHours();

            var result = x.GetTheNumberOfHoursByWorkType(startTime, endTime, bedTime);
            result[WorkHourType.Default].Should().Be(0, "The default billable time starts at bedtime");
            result[WorkHourType.BedTime].Should().Be(6, "The bed time billable time is from 6 till midnight");
            result[WorkHourType.AfterMidnight].Should().Be(2, "The after midnight billable time is from midnight till 1");
        }

        [Fact]
        public void ReturnsCorrectWorkTypeHoursWithBedTimeEqualToStartTimeAndEndTimeBeforeMidnight()
        {
            DateTime startTime = DateTime.Now.Date.AddHours(-6);
            DateTime endTime = DateTime.Now.Date.AddHours(-1);
            DateTime bedTime = DateTime.Now.Date.AddHours(-6);

            var x = new WorkTypeHours();

            var result = x.GetTheNumberOfHoursByWorkType(startTime, endTime, bedTime);
            result[WorkHourType.Default].Should().Be(0, "The default billable time starts at bedtime");
            result[WorkHourType.BedTime].Should().Be(5, "The bed time billable time is from 6 till 11");
            result[WorkHourType.AfterMidnight].Should().Be(0, "The end time is before midnight");
        }
    }
}
