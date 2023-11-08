using Budget.Application.Events.Requested.Creation;
using Budget.Application.Projections;
using Xunit;

namespace Budget.Application.Tests.Collaboration.Services.Creates
{
    public class CreateDepositServiceTests
    {
        public CreateDepositServiceTests()
        {
            Runtime.Stop();
            Runtime.Start();
        }

        [Fact]
        public void ShouldCreateProjection()
        {
            var @event = new DepositRequested();
            @event.Publish();
            var projection = Deposit.Projections[0];
            Assert.NotNull(projection);
        }
    }
}
