using Budget.Application.Events.Requested.Creation;
using Budget.Application.Projections;
using Budget.Application.Services.Creates;
using Xunit;

namespace Budget.Application.Tests.Collaboration.Services.Creates
{
    public class CreateTransactionServiceTests
    {
        [Fact]
        public void ShouldCreateProjection()
        {
            var service = new CreateTransactionService();
            var @event = new TransactionRequested();
            @event.Publish();
            var projection = Transaction.Projections[0];
            Assert.NotNull(projection);
        }
    }
}
