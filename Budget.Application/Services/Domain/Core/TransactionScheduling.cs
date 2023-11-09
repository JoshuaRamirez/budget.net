using Budget.Application.Projections;
using Budget.Application.Projections.Core;
using System;
using System.Collections.Generic;

namespace Budget.Application.Services.Domain.Core
{

    public class TransactionScheduling
    {
        public class Day
        {
            public DateTime Date { get; set; }
            public double Amount { get; set; }
        }
        public static List<Day> ApplyAmounts(List<Day> toDays, List<PlannedTransaction> plannedTransactions, double startingBalance)
        {
            var runningTotal = (double)0;
            if (startingBalance != 0)
            {
                runningTotal += startingBalance;
            }
            for (var i = 0; i < toDays.Count; i++)
            {
                var currentDay = toDays[i];
                foreach (var plannedTransaction in plannedTransactions)
                {
                    var startDate = plannedTransaction.StartDate;
                    if (hasPlanStarted(currentDay, startDate)) {
                        if (!isRecurrenceCountReached(plannedTransaction)) {
                            if (isForCurrentDay(currentDay, startDate, plannedTransaction.RepeatPeriod))
                            {
                                runningTotal = UpdateRunningTotal(runningTotal, plannedTransaction);
                                incrementTimesRepeated(plannedTransaction);
                            }
                        }
                    } 
                        
                }
                currentDay.Amount = runningTotal;
            }
            return toDays;
        }

        private static bool hasPlanStarted(Day currentDay, DateTime startDate)
        {
            return currentDay.Date >= startDate;
        }

        private static bool isRecurrenceCountReached(PlannedTransaction plannedTransaction)
        {
            return plannedTransaction.RepeatCount < plannedTransaction.TimesRepeated;
        }

        private static bool isForCurrentDay(Day currentDay, DateTime startDate, int repeatPeriod)
        {
            var currentDate = currentDay.Date;
            var isSameDay = currentDate.Year == startDate.Year &&
                            currentDate.Month == startDate.Month &&
                            currentDate.Day == startDate.Day;
            var differenceInDays = (currentDate - startDate).Days;
            var remainder = differenceInDays % repeatPeriod;
            return isSameDay || remainder == 0;
        }


        private static double UpdateRunningTotal(double runningTotal, PlannedTransaction plannedTransaction)
        {
            switch (plannedTransaction.TransactionType)
            {
                case TransactionType.Expense:
                    runningTotal -= plannedTransaction.Amount;
                    break;
                case TransactionType.Deposit:
                    runningTotal += plannedTransaction.Amount;
                    break;
                default:
                    throw new ArgumentException("TransactionType property doesn't match");
            }
            return runningTotal;
        }

        private static void incrementTimesRepeated(PlannedTransaction plannedTransaction)
        {
            plannedTransaction.TimesRepeated += 1;
        }

        public static List<Day> CreateDays(DateTime startDate, DateTime stopDate)
        {
            List<Day> days = new List<Day>();

            DateTime currentDate = startDate;
            while (currentDate <= stopDate)
            {
                Day day = new Day
                {
                    Date = currentDate,
                    Amount = 0
                };

                days.Add(day);
                currentDate = currentDate.AddDays(1);
            }

            return days;
        }

    }

}
