using Budget.Application.Events.Requested.Creation;
using Budget.Application.Projections;

namespace Budget.Application.Tests.Collaboration.Services.Creates;
[TestClass]
public class CreatePayeeServiceTests
{
    public CreatePayeeServiceTests()
    {
        Runtime.Stop();
        Runtime.Start();
    }

    [TestMethod]
    public void ShouldCreateProjection()
    {
        var @event = new PayeeRequested();
        @event.Publish();
        var projection = Payee.Projections[0];
        Assert.IsNotNull(projection);
    }
}