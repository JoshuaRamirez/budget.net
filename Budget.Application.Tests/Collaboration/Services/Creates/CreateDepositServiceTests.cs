using Budget.Application.Events.Requested.Creation;
using Budget.Application.Projections;
using Budget.Application.Services.Creates;
using Xunit;

namespace Budget.Application.Tests.Collaboration.Services.Creates
{
    public class CreateDepositServiceTests
    {
        [Fact]
        public void ShouldCreateProjection()
        {
            var service = new CreateDepositService();
            var @event = new DepositRequested();
            @event.Publish();
            var projection = Deposit.Projections[0];
            Assert.NotNull(projection);
        }
    }
}
