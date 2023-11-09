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
                var plannedTransactionIdsQuery = plannedTransactions.Select(x => x.Id);
                var plannedTransactionIds = plannedTransactionIdsQuery.ToList();
                var forecastRequestedEvent = new ForecastRequested
                {
                    Amount = day.Amount,
                    Date = day.Date,
                    PlannedTransactionIds = plannedTransactionIds,
                };
                forecastRequestedEvent.Publish();
            }
        }
    }
}
