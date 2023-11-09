using Budget.Application.Events.Created;
using Budget.Application.Events.Requested.Creation;
using Budget.Application.Projections;
using Budget.Application.Services.Core;
using System.Linq;

namespace Budget.Application.Services.Transformers
{
    public class PlannedExpenseCreatedToPlannedTransactionRequested : Transformer<PlannedExpenseCreated, PlannedTransactionRequested>
    {
        public static PlannedExpenseCreatedToPlannedTransactionRequested Instance { get; } = new PlannedExpenseCreatedToPlannedTransactionRequested();
        public PlannedExpenseCreatedToPlannedTransactionRequested() : base(plannedExpenseCreated =>
        {
            var plannedTransactionRequested = new PlannedTransactionRequested();
            var plannedExpense = PlannedExpense.Projections.Single(plannedExpense => plannedExpense.Id == plannedExpenseCreated.PlannedExpenseId);
            plannedTransactionRequested.Amount = plannedExpense.Amount;
            plannedTransactionRequested.Description = plannedExpense.Description;
            plannedTransactionRequested.PeriodMeasurement = plannedExpense.RepeatMeasurement;
            plannedTransactionRequested.RepeatCount = plannedExpense.RepeatCount;
            plannedTransactionRequested.RepeatPeriod = plannedExpense.RepeatPeriod;
            plannedTransactionRequested.StartDate = plannedExpense.StartDate;
            plannedTransactionRequested.TransactionType = Projections.Core.TransactionType.Expense;
            return plannedTransactionRequested;
        }) {}
    }
}
