using Budget.Application.Events.Created;
using Budget.Application.Events.Requested.Creation;
using Budget.Application.Projections;
using Budget.Application.Projections.Core;
using Budget.Application.Services.Core;
using System.Linq;

namespace Budget.Application.Services.Transformers
{
    public class PlannedDepositCreatedToPlannedTransactionRequested : Transformer<PlannedDepositCreated, PlannedTransactionRequested>
    {
        public static PlannedDepositCreatedToPlannedTransactionRequested Instance { get; } = new PlannedDepositCreatedToPlannedTransactionRequested();
        public PlannedDepositCreatedToPlannedTransactionRequested() : base(plannedDepositCreated =>
        {
            var plannedTransactionRequested = new PlannedTransactionRequested();
            var plannedDeposit = PlannedDeposit.Projections.Single(plannedDeposit => plannedDeposit.Id == plannedDepositCreated.PlannedDepositId);
            plannedTransactionRequested.Amount = plannedDeposit.Amount;
            plannedTransactionRequested.Description = plannedDeposit.Description;
            plannedTransactionRequested.PeriodMeasurement = plannedDeposit.PeriodMeasurement;
            plannedTransactionRequested.RepeatCount = plannedDeposit.RepeatCount;
            plannedTransactionRequested.RepeatPeriod = plannedDeposit.RepeatPeriod;
            plannedTransactionRequested.StartDate = plannedDeposit.StartDate;
            plannedTransactionRequested.TransactionType = TransactionType.Deposit;
            return plannedTransactionRequested;
        })
        { }
    }
}
