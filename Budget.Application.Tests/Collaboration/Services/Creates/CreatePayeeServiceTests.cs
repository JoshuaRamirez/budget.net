using Budget.Application.Events.Requested.Creation;
using Budget.Application.Projections;
using Budget.Application.Services.Creates;
using Xunit;

namespace Budget.Application.Tests.Collaboration.Services.Creates
{
    public class CreatePayeeServiceTests
    {
        public CreatePayeeServiceTests()
        {
            Runtime.Stop();
            Runtime.Start();
        }

        [Fact]
        public void ShouldCreateProjection()
        {
            var @event = new PayeeRequested();
            @event.Publish();
            var projection = Payee.Projections[0];
            Assert.NotNull(projection);
        }
    }
}
