using System;
using Budget.Application.Projections;

public class TransactionProposition
{
    public static DateTime GetProposedDate(PlannedTransaction plannedTransaction)
    {
        DateTime today = DateTime.Now;
        if (plannedTransaction.RepeatCount >= plannedTransaction.TimesRepeated)
        {
            throw new InvalidOperationException("The planned transaction has expired.");
        }
        if (plannedTransaction.StartDate > today)
        {
            throw new InvalidOperationException("The planned transaction hasn't started.");
        }
        DateTime proposedDate;
        if (plannedTransaction.ProposedTransactionIds.Count == 0)
        {
            proposedDate = plannedTransaction.StartDate;
        }
        else if (plannedTransaction.ProposedTransactionIds.Count > 0)
        {
            var lastProposedTransaction = ProposedTransaction.GetLast();
            DateTime nextDate = lastProposedTransaction.Date;
            switch (plannedTransaction.RepeatMeasurement)
            {
                case Budget.Application.Projections.Core.Period.Days:
                    nextDate = nextDate.AddDays(plannedTransaction.RepeatPeriod);
                    break;
                case Budget.Application.Projections.Core.Period.Weeks:
                    nextDate = nextDate.AddDays(plannedTransaction.RepeatPeriod * 7);
                    break;
                case Budget.Application.Projections.Core.Period.Months:
                    nextDate = nextDate.AddMonths(plannedTransaction.RepeatPeriod);
                    break;
                case Budget.Application.Projections.Core.Period.Years:
                    nextDate = nextDate.AddYears(plannedTransaction.RepeatPeriod);
                    break;
                default:
                    break;
            }
            proposedDate = nextDate;
        }
        else
        {
            throw new Exception("Invalid state"); // Adjust error handling as needed
        }
        return proposedDate;
    }
}