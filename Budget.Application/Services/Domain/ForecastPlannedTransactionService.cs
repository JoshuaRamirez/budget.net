using Budget.Application.Events.Requested.Creation;
using Budget.Application.Projections;
using Budget.Application.Services.Core;
using Budget.Application.Services.Domain.Core;
using System;
using Budget.Application.Events.Requested.Calculation;
using System.Linq;

namespace Budget.Application.Services.Domain
{
    public class ForecastPlannedTransactionsService : Receiver<ForecastCalculationRequested>
    {
        public static ForecastPlannedTransactionsService Instance { get; } = new ForecastPlannedTransactionsService();
        public override void Serve(ForecastCalculationRequested @event)
        {
            var startDate = @event.StartDate;
            var endDate = @event.EndDate;
            startDate = startDate.Date;
            endDate = endDate.Date;
            if (startDate > endDate)
            {
                return;
            }
            var days = TransactionScheduling.CreateDays(startDate, endDate);
            var plannedTransactions = PlannedTransaction.GetAll();
            if (plannedTransactions.Count == 0)
            {
                throw new Exception("Missing PlannedTransactionProjection Data.");
            }
            var startingBalance = @event.StartingBalance;
            days = TransactionScheduling.ApplyAmounts(days, plannedTransactions, startingBalance);
            foreach (var day in days)
            {
                var plannedDeposits = PlannedDeposit.GetAll();
                var plannedDepositIdsQuery = plannedDeposits.Select(plannedDeposit => plannedDeposit.Id);
                var plannedDepositIds = plannedDepositIdsQuery.ToList();
                var plannedExpenses = PlannedExpense.GetAll();
                var plannedExpenseIdsQuery = plannedExpenses.Select(plannedExpense => plannedExpense.Id);
                var plannedExpenseIds = plannedExpenseIdsQuery.ToList();
                var forecastRequestedEvent = new ForecastRequested
                {
                    Amount = day.Amount,
                    Date = day.Date,
                    PlannedDepositIds = plannedDepositIds,
                    PlannedExpenseIds = plannedExpenseIds
                };
                forecastRequestedEvent.Publish();
            }
        }
    }
}
