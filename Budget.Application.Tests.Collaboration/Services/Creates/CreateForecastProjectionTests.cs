using Budget.Application.Events.Requested.Creation;
using Budget.Application.Projections;

namespace Budget.Application.Tests.Collaboration.Services.Creates;
[TestClass]
public class CreateForecastProjectionTests
{
    public CreateForecastProjectionTests()
    {
        Runtime.Stop();
        Runtime.Start();
    }

    [TestMethod]
    public void ShouldCreateProjection()
    {
        var @event = new ForecastRequested();
        @event.Publish();
        var projection = Forecast.Projections[0];
        Assert.IsNotNull(projection);
    }
}