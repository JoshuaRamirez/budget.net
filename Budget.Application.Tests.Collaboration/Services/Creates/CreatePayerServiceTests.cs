using Budget.Application.Events.Requested.Creation;
using Budget.Application.Projections;

namespace Budget.Application.Tests.Collaboration.Services.Creates;
[TestClass]
public class CreatePayerServiceTests
{
    public CreatePayerServiceTests()
    {
        Runtime.Stop();
        Runtime.Start();
    }

    [TestMethod]
    public void ShouldCreateProjection()
    {
        var @event = new PayerRequested();
        @event.Publish();
        var projection = Payer.Projections[0];
        Assert.IsNotNull(projection);
    }
}