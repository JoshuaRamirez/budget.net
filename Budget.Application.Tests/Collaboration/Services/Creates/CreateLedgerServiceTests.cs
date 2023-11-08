using Budget.Application.Events.Requested.Creation;
using Budget.Application.Projections;
using Xunit;

namespace Budget.Application.Tests.Collaboration.Services.Creates
{
    public class CreateLedgerServiceTests
    {
        public CreateLedgerServiceTests()
        {
            Runtime.Stop();
            Runtime.Start();
        }

        [Fact]
        public void ShouldCreateProjection()
        {
            var @event = new LedgerRequested();
            @event.Publish();
            var projection = Ledger.Projections[0];
            Assert.NotNull(projection);
        }
    }
}
