using Budget.Application.Events.Requested.Creation;
using Budget.Application.Projections;
using Budget.Application.Projections.Core;

namespace Budget.Application.Tests.Collaboration.Services.Creates;
[TestClass]
public class CreatePlannedDepositServiceTests
{
    public CreatePlannedDepositServiceTests()
    {
        Runtime.Stop();
        Runtime.Start();
    }

    [TestMethod]
    public void ShouldCreateProjection()
    {
        var @event = new PlannedDepositRequested();
        @event.Amount = 100;
        @event.LedgerId = Guid.NewGuid();
        @event.RepeatCount = 1;
        @event.RepeatMeasurement = Period.Days;
        @event.RepeatPeriod = 1;
        @event.StartDate = DateTime.Now;
        @event.Publish();
        var projection = PlannedDeposit.Projections[0];
        Assert.IsNotNull(projection);
    }
}