using Budget.Application.Events.Requested.Creation;
using Budget.Application.Projections;
using Budget.Application.Services.Creates;
using Xunit;

namespace Budget.Application.Tests.Collaboration.Services.Creates
{
    public class CreatePlannedTransactionServiceTests
    {
        [Fact]
        public void ShouldCreateProjection()
        {
            var service = new CreatePlannedTransactionService();
            var @event = new PlannedTransactionRequested();
            @event.Publish();
            var projection = PlannedTransaction.Projections[0];
            Assert.NotNull(projection);
        }
    }
}
