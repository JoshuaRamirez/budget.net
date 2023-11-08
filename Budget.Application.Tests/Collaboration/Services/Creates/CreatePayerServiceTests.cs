using Budget.Application.Events.Requested.Creation;
using Budget.Application.Projections;
using Xunit;

namespace Budget.Application.Tests.Collaboration.Services.Creates
{
    public class CreatePayerServiceTests
    {
        public CreatePayerServiceTests()
        {
            Runtime.Stop();
            Runtime.Start();
        }

        [Fact]
        public void ShouldCreateProjection()
        {
            var @event = new PayerRequested();
            @event.Publish();
            var projection = Payer.Projections[0];
            Assert.NotNull(projection);
        }
    }
}
