using Budget.Application.Events.Requested.Creation;
using Budget.Application.Projections;
using Budget.Application.Services.Creates;
using Xunit;

namespace Budget.Application.Tests.Collaboration.Services.Creates
{
    public class CreateAllocationServiceTests
    {
        [Fact]
        public void ShouldCreateProjection()
        {
            var service = new CreateAllocationService();
            var @event = new AllocationRequested();
            @event.Publish();
            var projection = Allocation.Projections[0];
            Assert.NotNull(projection);
        }
    }
}
