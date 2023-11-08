using Budget.Application.Events.Requested.Creation;
using Budget.Application.Projections;
using Xunit;

namespace Budget.Application.Tests.Collaboration.Services.Creates
{
    public class CreateForecastProjectionTests
    {
        public CreateForecastProjectionTests()
        {
            Runtime.Stop();
            Runtime.Start();
        }

        [Fact]
        public void ShouldCreateProjection()
        {
            var @event = new ForecastRequested();
            @event.Publish();
            var projection = Forecast.Projections[0];
            Assert.NotNull(projection);
        }
    }
}
