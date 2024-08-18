using Budget.Application.Events.Requested.Creation;
using Budget.Application.Projections;

namespace Budget.Application.Tests.Collaboration.Services.Creates;
[TestClass]
public class CreateCategoryServiceTests
{
    public CreateCategoryServiceTests()
    {
        Runtime.Stop();
        Runtime.Start();
    }

    [TestMethod]
    public void ShouldCreateProjection()
    {
        var @event = new CategoryRequested();
        @event.Publish();
        var projection = Category.Projections[0];
        Assert.IsNotNull(projection);
    }
}