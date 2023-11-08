using Budget.Application.Events.Requested.Creation;
using Budget.Application.Events.System;
using Budget.Application.Projections;
using Budget.Application.Services.Core;

namespace Budget.Application.Services.Domain
{
    public class ProposeTransactionsForTodayService : Receiver<DailyTimerIntervalTicked>
    {
        public static ProposeTransactionsForTodayService Instance { get; } = new ProposeTransactionsForTodayService();
        public override void Serve(DailyTimerIntervalTicked @event)
        {
            var plannedTransactionProjections = PlannedTransaction.GetAll();
            foreach (var plannedTransactionProjection in plannedTransactionProjections)
            {
                var proposedDate = TransactionProposition.GetProposedDate(plannedTransactionProjection);
                var proposedTransactionCreationRequestedEvent = new ProposedTransactionRequested();
                proposedTransactionCreationRequestedEvent.Amount = plannedTransactionProjection.Amount;
                proposedTransactionCreationRequestedEvent.Description = plannedTransactionProjection.Description;
                proposedTransactionCreationRequestedEvent.PlannedTransactionId = plannedTransactionProjection.Id;
                proposedTransactionCreationRequestedEvent.Date = proposedDate;
                if (proposedTransactionCreationRequestedEvent != null)
                {
                    proposedTransactionCreationRequestedEvent.Publish();
                }
            }
        }
    }
}
