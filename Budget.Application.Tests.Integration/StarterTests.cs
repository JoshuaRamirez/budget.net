using Budget.Application.Events.Requested.Creation;
using Budget.Application.Projections;

namespace Budget.Application.Tests.Integration;
[TestClass]
public class StarterTests
{
    public StarterTests()
    {
        Runtime.Stop();
        Runtime.Start();
    }

    [TestMethod]
    public void Test()
    {
        // Request a User
        var userRequestedEvent = new UserRequested();
        userRequestedEvent.UserName = "Test User";
        UserRequested.Publish(userRequestedEvent);

        // Assert Account Exists
        var accountCount = Account.Projections.Count;
        Assert.AreEqual(1, accountCount);

        // Assert User Exists
        var userCount = Account.Projections.Count;
        Assert.AreEqual(1, userCount);

        //Assert Account is Linked to User
        var account = Account.Projections.Last();
        var user = UserProjection.Projections.Last();
        Assert.AreEqual(account.UserId, user.Id);
        Assert.AreEqual(user.AccountIds.Last(), account.Id);
    }
}