using Budget.Application.Events.Requested.Creation;
using Budget.Application.Projections;
using Budget.Application.Services.Creates;
using Xunit;

namespace Budget.Application.Tests.Collaboration.Services.Creates
{
    public class CreateTransactionServiceTests
    {
        public CreateTransactionServiceTests()
        {
            Runtime.Stop();
            Runtime.Start();
        }

        [Fact]
        public void ShouldCreateProjection()
        {
            new UserRequested().Publish();
            var ledger = Ledger.Projections[0];
            var @event = new TransactionRequested();
            @event.LedgerId = ledger.Id;
            @event.Publish();
            var projection = Transaction.Projections[0];
            Assert.NotNull(projection);
        }
    }
}
