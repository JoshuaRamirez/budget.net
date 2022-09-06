using Budget.Application.Events.Requested.Creation;
using Budget.Application.Projections;
using Budget.Application.Services.Creates;
using Budget.Application.Services.Links;
using System;
using System.Linq;
using Xunit;

namespace Budget.Application.Tests.Scenarios
{
    public class StarterTests
    {
        [Fact]
        public void Test()
        {
            // Startup the Services
            var createUserService = new CreateUserService();
            var createAccountService = new CreateAccountService();
            var linkAccountToUserService = new AccountToUser();

            // Request a User
            var userRequestedEvent = new UserRequested();
            userRequestedEvent.UserName = "Test User";
            UserRequested.Publish(userRequestedEvent);

            // Request an Account
            var accountRequestedEvent = new AccountRequested();
            accountRequestedEvent.AccountName = "Test Account";
            accountRequestedEvent.UserId = User.Projections.Last().Id;
            AccountRequested.Publish(accountRequestedEvent);

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
            Assert.Equal(user.AccountIds[0], account.Id);
        }
    }
}
