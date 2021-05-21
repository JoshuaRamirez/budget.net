using Budget.Application.Events.Core;
using Budget.Application.Events.Created;
using Budget.Application.Events.Requested.Creation;
using Budget.Application.Services.Core;

namespace Budget.Application.Services.Transformers
{
    public class PlannedTransactionCreatedToProposedTransactionRequested : Transformer<PlannedTransactionCreated, ProposedTransactionRequested>
    {
        public PlannedTransactionCreatedToProposedTransactionRequested() : base(Mappers.PlannedTransactionCreatedToProposedTransactionRequested) {}
    }
}
