using Budget.Application.Events.Requested.Creation;
using Budget.Application.Projections;
using Xunit;

namespace Budget.Application.Tests.Collaboration.Services.Creates
{
    public class CreatePlannedTransactionServiceTests
    {
        public CreatePlannedTransactionServiceTests()
        {
            Runtime.Stop();
            Runtime.Start();
        }

        [Fact]
        public void ShouldCreateProjection()
        {
            var @event = new PlannedTransactionRequested();
            @event.Publish();
            var projection = PlannedTransaction.Projections[0];
            Assert.NotNull(projection);
        }
    }
}
