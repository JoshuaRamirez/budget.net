using Budget.Application.Events.Requested.Creation;
using Budget.Application.Projections;
using System.Linq;
using Xunit;

namespace Budget.Application.Tests.Scenarios
{
    public class MultipleAccountReconciliation
    {
        public MultipleAccountReconciliation()
        {
            Runtime.Stop();
            Runtime.Start();
        }
        [Fact]
        public void Stuff()
        {
            // Request a User
            var userRequestedEvent = new UserRequested();
            userRequestedEvent.UserName = "Test User";
            UserRequested.Publish(userRequestedEvent);

            // Get Account
            var account = Account.Projections[0];
            
        }
    }
}
