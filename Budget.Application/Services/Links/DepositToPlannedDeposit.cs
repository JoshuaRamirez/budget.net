using Budget.Application.Events.Created;
using Budget.Application.Projection;
using Budget.Application.Services.Core;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Budget.Application.Services.Links
{
    public class DepositToPlannedDeposit : Linker<DepositCreated, Deposit, PlannedDeposit>
    {
        internal override List<Guid> GetSourceIds(DepositCreated @event)
        {
            return Guids(@event.DepositId);
        }
        internal override List<Guid> GetTargetIds(List<Deposit> sources)
        {
            return Guids(sources.Select(x => x.PlannedDepositId));
        }
        internal override void Link(Deposit source, PlannedDeposit target)
        {
            target.DepositIds.Add(source.Id);
        }
    }
}