using Budget.Application.Events.Requested.Creation;
using Budget.Application.Projections;
using Budget.Application.Services.Creates;
using Xunit;

namespace Budget.Application.Tests.Collaboration.Services.Creates
{
    public class CreatePayeeServiceTests
    {
        [Fact]
        public void ShouldCreateProjection()
        {
            var service = new CreatePayeeService();
            var @event = new PayeeRequested();
            @event.Publish();
            var projection = Payee.Projections[0];
            Assert.NotNull(projection);
        }
    }
}
