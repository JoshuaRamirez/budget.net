using Budget.Application.Events.Requested.Creation;
using Budget.Application.Projections;

namespace Budget.Application.Tests.Collaboration.Services.Creates;
[TestClass]
public class CreateUserServiceTests
{
    public CreateUserServiceTests()
    {
        Runtime.Stop();
        Runtime.Start();
    }

    [TestMethod]
    public void ShouldCreateProjection()
    {
        var @event = new UserRequested();
        @event.Publish();
        var projection = UserProjection.Projections[0];
        Assert.IsNotNull(projection);
    }
}