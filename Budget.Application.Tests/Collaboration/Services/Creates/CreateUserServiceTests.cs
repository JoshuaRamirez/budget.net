using Budget.Application.Events.Requested.Creation;
using Budget.Application.Projections;
using Budget.Application.Services.Creates;
using Xunit;

namespace Budget.Application.Tests.Collaboration.Services.Creates
{
    public class CreateUserServiceTests
    {
        [Fact]
        public void ShouldCreateProjection()
        {
            var service = new CreateUserService();
            var @event = new UserRequested();
            @event.Publish();
            var projection = User.Projections[0];
            Assert.NotNull(projection);
        }
    }
}
