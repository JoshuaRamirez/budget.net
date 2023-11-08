using Budget.Application.Events.Created;
using Budget.Application.Projections;
using Budget.Application.Services.Core;

public class IncrementProposedTransactionCounterService : Receiver<ProposedTransactionCreated>
{
    public static IncrementProposedTransactionCounterService Instance { get; } = new IncrementProposedTransactionCounterService();

    public override void Serve(ProposedTransactionCreated @event)
    {
        var proposedTransaction = ProposedTransaction.Get(@event.ProposedTransactionId);
        var plannedTransaction = PlannedTransaction.Get(proposedTransaction.PlannedTransactionId);
        plannedTransaction.TimesRepeated += 1;
        plannedTransaction.Save();
    }
}
