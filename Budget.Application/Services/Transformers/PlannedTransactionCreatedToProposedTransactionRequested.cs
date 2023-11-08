using Budget.Application.Events.Created;
using Budget.Application.Events.Requested.Creation;
using Budget.Application.Projections;
using Budget.Application.Services.Core;
using System.Linq;

namespace Budget.Application.Services.Transformers
{
    public class PlannedTransactionCreatedToProposedTransactionRequested : Transformer<PlannedTransactionCreated, ProposedTransactionRequested>
    {
        public static PlannedTransactionCreatedToProposedTransactionRequested Instance { get; } = new PlannedTransactionCreatedToProposedTransactionRequested();
        public PlannedTransactionCreatedToProposedTransactionRequested() : base(plannedTransactionCreated =>
        {
            var proposedTransactionRequested = new ProposedTransactionRequested();
            var plannedTransaction = PlannedTransaction.Projections.Single(p => p.Id == plannedTransactionCreated.PlannedTransactionId);
            proposedTransactionRequested.Amount = plannedTransaction.Amount;
            proposedTransactionRequested.Date = plannedTransaction.Date;
            proposedTransactionRequested.Description = plannedTransaction.Description;
            proposedTransactionRequested.PlannedTransactionId = plannedTransaction.Id;
            proposedTransactionRequested.TransactionType = plannedTransaction.TransactionType;
            return proposedTransactionRequested;
        }) {}
    }
}
