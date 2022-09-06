using Budget.Application.Events.Requested.Creation;
using Budget.Application.Projections;
using Budget.Application.Services.Creates;
using Xunit;

namespace Budget.Application.Tests.Collaboration.Services.Creates
{
    public class CreatePayerServiceTests
    {
        [Fact]
        public void ShouldCreateProjection()
        {
            var service = new CreatePayerService();
            var @event = new PayerRequested();
            @event.Publish();
            var projection = Payer.Projections[0];
            Assert.NotNull(projection);
        }
    }
}
