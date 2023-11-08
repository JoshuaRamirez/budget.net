using Budget.Application.Events.Requested.Creation;
using Budget.Application.Projections;
using Budget.Application.Services.Creates;
using Xunit;

namespace Budget.Application.Tests.Collaboration.Services.Creates
{
    public class CreateAccountServiceTests
    {
        public CreateAccountServiceTests()
        {
            Runtime.Stop();
            Runtime.Start();
        }

        [Fact]
        public void ShouldCreateProjection()
        {
            var @event = new AccountRequested();
            @event.Publish();
            var projection = Account.Projections[0];
            Assert.NotNull(projection);
        }
    }
}
