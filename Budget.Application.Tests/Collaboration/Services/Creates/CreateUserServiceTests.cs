using Budget.Application.Events.Requested.Creation;
using Budget.Application.Projections;
using Xunit;

namespace Budget.Application.Tests.Collaboration.Services.Creates
{
    public class CreateUserServiceTests
    {
        public CreateUserServiceTests()
        {
            Runtime.Stop();
            Runtime.Start();
        }
        [Fact]
        public void ShouldCreateProjection()
        {
            var @event = new UserRequested();
            @event.Publish();
            var projection = User.Projections[0];
            Assert.NotNull(projection);
        }
    }
}
