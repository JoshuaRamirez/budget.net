using Budget.Application.Events.Requested.Creation;
using Budget.Application.Projections;
using Budget.Application.Services.Creates;
using Xunit;

namespace Budget.Application.Tests.Collaboration.Services.Creates
{
    public class CreateProposedTransactionServiceTests
    {
        [Fact]
        public void ShouldCreateProjection()
        {
            var service = new CreateProposedTransactionService();
            var @event = new ProposedTransactionRequested();
            @event.Publish();
            var projection = ProposedTransaction.Projections[0];
            Assert.NotNull(projection);
        }
    }
}
