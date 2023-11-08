using Budget.Application.Events.Requested.Creation;
using Budget.Application.Projections;
using Budget.Application.Projections.Core;
using Budget.Application.Services.Creates;
using System;
using Xunit;

namespace Budget.Application.Tests.Collaboration.Services.Creates
{
    public class CreateProposedTransactionServiceTests
    {
        public CreateProposedTransactionServiceTests()
        {
            Runtime.Stop();
            Runtime.Start();
        }

        [Fact]
        public void ShouldCreateProjection()
        {
            //TODO: The idea of this test is no longer relavent now that all the subscriptions run. The planned deposit trickles down to this behavior.
            new UserRequested().Publish();
            var plannedExpenseRequested = new PlannedExpenseRequested();
            plannedExpenseRequested.Amount = 10;
            plannedExpenseRequested.RepeatMeasurement = Repetition.Days;
            plannedExpenseRequested.RepeatPeriod = 1;
            plannedExpenseRequested.StartDate = DateTime.Now;
            plannedExpenseRequested.Publish();
            var projection = ProposedTransaction.Projections[0];
            Assert.NotNull(projection);
        }
    }
}
