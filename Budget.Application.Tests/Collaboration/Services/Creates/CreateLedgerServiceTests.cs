using Budget.Application.Events.Requested.Creation;
using Budget.Application.Projections;
using Budget.Application.Services.Creates;
using Xunit;

namespace Budget.Application.Tests.Collaboration.Services.Creates
{
    public class CreateLedgerServiceTests
    {
        [Fact]
        public void ShouldCreateProjection()
        {
            var service = new CreateLedgerService();
            var @event = new LedgerRequested();
            @event.Publish();
            var projection = Ledger.Projections[0];
            Assert.NotNull(projection);
        }
    }
}
