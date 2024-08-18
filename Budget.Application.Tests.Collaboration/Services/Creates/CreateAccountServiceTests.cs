using Budget.Application.Events.Requested.Creation;
using Budget.Application.Projections;

namespace Budget.Application.Tests.Collaboration.Services.Creates;
[TestClass]
public class CreateAccountServiceTests
{
    public CreateAccountServiceTests()
    {
        Runtime.Stop();
        Runtime.Start();
    }

    [TestMethod]
    public void ShouldCreateProjection()
    {
        var @event = new AccountRequested();
        @event.UserId = Guid.NewGuid();
        @event.Publish();
        var projection = Account.Projections[0];
        Assert.IsNotNull(projection);
    }
}