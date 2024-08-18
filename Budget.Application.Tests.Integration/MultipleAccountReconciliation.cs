using Budget.Application.Events.Requested.Creation;
using Budget.Application.Projections;

namespace Budget.Application.Tests.Integration;
[TestClass]
public class MultipleAccountReconciliation
{
    public MultipleAccountReconciliation()
    {
        Runtime.Stop();
        Runtime.Start();
    }

    [TestMethod]
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