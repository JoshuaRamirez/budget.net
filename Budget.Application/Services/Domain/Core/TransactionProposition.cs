using System;
using Budget.Application.Projections;

public class TransactionProposition
{
    public static DateTime GetProposedDate(PlannedTransaction plannedTransaction)
    {
        DateTime today = DateTime.Now;
        if (plannedTransaction.RepeatCount >= plannedTransaction.TimesRepeated)
        {
            return default;
        }
        if (plannedTransaction.StartDate > today)
        {
            return default;
        }
        DateTime proposedDate;
        if (plannedTransaction.ProposedTransactionIds.Count == 0)
        {
            proposedDate = plannedTransaction.StartDate;
        }
        else if (plannedTransaction.ProposedTransactionIds.Count > 0)
        {
            var lastProposedTransaction = PlannedTransaction.GetLast();
            DateTime nextDate = lastProposedTransaction.Date;
            nextDate = nextDate.AddDays(plannedTransaction.RepeatPeriod);
            proposedDate = nextDate;
        }
        else
        {
            throw new Exception("Invalid state"); // Adjust error handling as needed
        }
        return proposedDate;
    }
}