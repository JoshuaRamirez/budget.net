using Budget.Application.Events.Requested.Creation;
using Budget.Application.Projections;

namespace Budget.Application.Tests.Collaboration.Services.Creates;
[TestClass]
public class CreateAllocationServiceTests
{
    public CreateAllocationServiceTests()
    {
        Runtime.Stop();
        Runtime.Start();
    }

    [TestMethod]
    public void ShouldCreateProjection()
    {
        var @event = new AllocationRequested();
        @event.Publish();
        var projection = Allocation.Projections[0];
        Assert.IsNotNull(projection);
    }
}