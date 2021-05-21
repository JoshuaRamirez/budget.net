using Budget.Application.Events.Requested.Creation;
using Budget.Application.Projection;
using Budget.Application.Services.Creates;
using Budget.Application.Services.Links;
using System;
using Xunit;

namespace Budget.Application.Tests
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
            userRequestedEvent.UserName = "Joshua Ramirez";
            UserRequested.Publish(userRequestedEvent);

            // Request an Account
            var accountRequestedEvent = new AccountRequested();
            accountRequestedEvent.AccountName = "Moneypants";
            accountRequestedEvent.UserId = User.Projections[0].Id;
            AccountRequested.Publish(accountRequestedEvent);
            
            // Assert Account Exists
            var accountCount = Account.Projections.Count;
            Assert.Equal(1, accountCount);

            // Assert User Exists
            var userCount = Account.Projections.Count;
            Assert.Equal(1, userCount);

            //Assert Account is Linked to User
            var account = Account.Projections[0];
            var user = User.Projections[0];
            Assert.Equal(account.UserId, user.Id);
            Assert.Equal(user.AccountIds[0], account.Id);
        }
    }
}
