using Budget.Application.Events.Requested.Creation;
using Budget.Application.Projections;
using Budget.Application.Services.Creates;
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
            
            // Request a User
            var userRequestedEvent = new UserRequestedEvent();
            userRequestedEvent.UserName = "Joshua Ramirez";
            UserRequestedEvent.Publish(userRequestedEvent);

            // Request an Account
            var accountRequestedEvent = new AccountRequestedEvent();
            accountRequestedEvent.AccountName = "Moneypants";
            AccountRequestedEvent.Publish(accountRequestedEvent);
            
            // Assert Account Exists
            var accountCount = AccountProjection.Projections.Count;
            Assert.Equal(1, accountCount);

            // Assert User Exists
            var userCount = AccountProjection.Projections.Count;
            Assert.Equal(1, userCount);
        }
    }
}
