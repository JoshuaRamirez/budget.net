using Budget.Application.Events.Requested.Creation;
using Budget.Application.Projections;
using Budget.Application.Projections.Core;
using System;
using Xunit;

namespace Budget.Application.Tests.Collaboration.Services.Creates
{
    public class CreatePlannedExpenseServiceTests
    {
        public CreatePlannedExpenseServiceTests()
        {
            Runtime.Stop();
            Runtime.Start();
        }

        [Fact]
        public void ShouldCreateProjection()
        {
            var @event = new PlannedExpenseRequested();
            @event.Amount = 100;
            @event.LedgerId = Guid.NewGuid();
            @event.RepeatCount = 1;
            @event.RepeatMeasurement = Period.Days;
            @event.RepeatPeriod = 1;
            @event.StartDate = DateTime.Now;
            @event.Publish();
            var projection = PlannedExpense.Projections[0];
            Assert.NotNull(projection);
        }
    }
}
