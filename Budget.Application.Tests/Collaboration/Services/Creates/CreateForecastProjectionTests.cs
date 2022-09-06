using Budget.Application.Events.Requested.Creation;
using Budget.Application.Projections;
using Budget.Application.Services.Creates;
using Xunit;

namespace Budget.Application.Tests.Collaboration.Services.Creates
{
    public class CreateForecastProjectionTests
    {
        [Fact]
        public void ShouldCreateProjection()
        {
            var service = new CreateForecastService();
            var @event = new ForecastRequested();
            @event.Publish();
            var projection = Forecast.Projections[0];
            Assert.NotNull(projection);
        }
    }
}
