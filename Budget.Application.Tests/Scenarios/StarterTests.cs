using Budget.Application.Events.Requested.Creation;
using Budget.Application.Projections;
using System.Linq;
using Xunit;

namespace Budget.Application.Tests.Scenarios
{
    public class StarterTests
    {
        public StarterTests()
        {
            Runtime.Stop();
            Runtime.Start();
        }

        [Fact]
        public void Test()
        {

            // Request a User
            var userRequestedEvent = new UserRequested();
            userRequestedEvent.UserName = "Test User";
            UserRequested.Publish(userRequestedEvent);

            // Assert Account Exists
            var accountCount = Account.Projections.Count;
            Assert.Equal(1, accountCount);

            // Assert User Exists
            var userCount = Account.Projections.Count;
            Assert.Equal(1, userCount);

            //Assert Account is Linked to User
            var account = Account.Projections.Last();
            var user = User.Projections.Last();
            Assert.Equal(account.UserId, user.Id);
            Assert.Equal(user.AccountIds.Last(), account.Id);
        }
    }
}
