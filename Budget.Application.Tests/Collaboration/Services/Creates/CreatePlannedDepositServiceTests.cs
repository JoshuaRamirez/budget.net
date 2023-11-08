using Budget.Application.Events.Requested.Creation;
using Budget.Application.Projections;
using Xunit;

namespace Budget.Application.Tests.Collaboration.Services.Creates
{
    public class CreatePlannedDepositServiceTests
    {
        public CreatePlannedDepositServiceTests()
        {
            Runtime.Stop();
            Runtime.Start();
        }

        [Fact]
        public void ShouldCreateProjection()
        {
            var @event = new PlannedDepositRequested();
            @event.Publish();
            var projection = PlannedDeposit.Projections[0];
            Assert.NotNull(projection);
        }
    }
}
