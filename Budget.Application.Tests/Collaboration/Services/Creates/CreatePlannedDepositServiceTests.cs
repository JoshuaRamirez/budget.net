using Budget.Application.Events.Requested.Creation;
using Budget.Application.Projections;
using Budget.Application.Services.Creates;
using Xunit;

namespace Budget.Application.Tests.Collaboration.Services.Creates
{
    public class CreatePlannedDepositServiceTests
    {
        [Fact]
        public void ShouldCreateProjection()
        {
            var service = new CreatePlannedDepositService();
            var @event = new PlannedDepositRequested();
            @event.Publish();
            var projection = PlannedDeposit.Projections[0];
            Assert.NotNull(projection);
        }
    }
}
