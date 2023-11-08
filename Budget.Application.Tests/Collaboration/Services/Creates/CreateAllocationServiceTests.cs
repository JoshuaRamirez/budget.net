using Budget.Application.Events.Requested.Creation;
using Budget.Application.Projections;
using Xunit;

namespace Budget.Application.Tests.Collaboration.Services.Creates
{
    public class CreateAllocationServiceTests
    {
        public CreateAllocationServiceTests()
        {
            Runtime.Stop();
            Runtime.Start();
        }

        [Fact]
        public void ShouldCreateProjection()
        {
            var @event = new AllocationRequested();
            @event.Publish();
            var projection = Allocation.Projections[0];
            Assert.NotNull(projection);
        }
    }
}
