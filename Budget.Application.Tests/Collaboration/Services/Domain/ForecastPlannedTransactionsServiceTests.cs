using System;
using Xunit;
using Budget.Application.Projections;
using Budget.Application.Events.Requested.Creation;
using Budget.Application.Events.Requested.Calculation;
using Budget.Application;
using Budget.Application.Projections.Core;

public class ForecastPlannedTransactionsServiceTests
{

    public struct Context
    {
        public int Amount { get; set; }
        public DateTime EndDate { get; set; }
        public int ExpectedFinalDepositAmount { get; set; }
        public int ExpectedFinalExpenseAmount { get; set; }
        public int ExpectedNumberOfForecasts { get; set; }
        public int RepeatPeriod { get; set; }
        public DateTime RepeatStart { get; set; }
        public DateTime StartDate { get; set; }
    }


    private void PublishPlannedTransactionCreationRequestEvent(string type, double amount, DateTime repeatStart, int repeatPeriod, int repeatCount)
    {
        
        if (type == "Deposit")
        {
            var plannedDepositRequested = new PlannedDepositRequested();
            plannedDepositRequested.Amount = amount;
            plannedDepositRequested.LedgerId = Ledger.Projections[0].Id;
            plannedDepositRequested.RepeatCount = repeatCount;
            plannedDepositRequested.RepeatPeriod = repeatPeriod;
            plannedDepositRequested.StartDate = repeatStart;
            plannedDepositRequested.RepeatMeasurement = Repetition.Days;
            plannedDepositRequested.Publish();
        }
        else if (type == "Expense")
        {
            var plannedExpenseRequested = new PlannedExpenseRequested();
            plannedExpenseRequested.Amount = amount;
            plannedExpenseRequested.LedgerId = Ledger.Projections[0].Id;
            plannedExpenseRequested.RepeatCount = repeatCount;
            plannedExpenseRequested.RepeatPeriod = repeatPeriod;
            plannedExpenseRequested.StartDate = repeatStart;
            plannedExpenseRequested.RepeatMeasurement = Repetition.Days;
            plannedExpenseRequested.Publish();
        }
        else
        {
            throw new ArgumentException("Invalid planned transaction type.");
        }
    }

    private ForecastCalculationRequested CreateForecastCalculationRequestedEvent(int forecastDayCount)
    {
        var startDate = new DateTime(2019, 1, 1);
        var endDate = startDate.AddDays(forecastDayCount - 1);

        var forecastCalculationRequested = new ForecastCalculationRequested
        {
            StartDate = startDate,
            EndDate = endDate
        };

        return forecastCalculationRequested;
    }

    private void CheckForSingleTransactionPlanResults(string type, double amount, int repeatPeriod, int forecastDayCount)
    {
        var startDate = new DateTime(2019, 1, 1);
        var forecastProjections = Forecast.GetAll();

        Assert.Equal(forecastDayCount, forecastProjections.Count);

        var thisDate = new DateTime(startDate.Ticks);
        double amountTotal = Math.Ceiling((double)forecastDayCount / repeatPeriod) * amount;
        if (type == "Expense")
        {
            amountTotal = -amountTotal;
        }

        foreach (var forecastProjection in forecastProjections)
        {
            Assert.Equal(amountTotal, forecastProjections[forecastProjections.Count - 1].Amount);
            Assert.Equal(thisDate, forecastProjection.Date);
            thisDate = thisDate.AddDays(1);
        }
    }

    private void ActWithSingleDeposit(double amount, DateTime repeatStart, int repeatPeriod, DateTime startDate, DateTime endDate)
    {
        PublishPlannedDepositRequestedEvent(amount, repeatStart, repeatPeriod);
        PublishForecastCalculationRequestedEvent(startDate, endDate);
    }

    private void ActWithSingleExpense(double amount, DateTime repeatStart, int repeatPeriod, DateTime startDate, DateTime endDate)
    {
        PublishPlannedExpenseRequestedEvent(amount, repeatStart, repeatPeriod);
        PublishForecastCalculationRequestedEvent(startDate, endDate);
    }

    private void PublishPlannedDepositRequestedEvent(double amount, DateTime startDate, int repeatPeriod)
    {
        var plannedDepositRequestedEvent = new PlannedDepositRequested
        {
            Amount = amount,
            LedgerId = Guid.NewGuid(),
            RepeatPeriod = repeatPeriod,
            RepeatCount = 1,
            RepeatMeasurement = Repetition.Days,
            StartDate = startDate
        };

        plannedDepositRequestedEvent.Publish();
    }

    private void PublishPlannedExpenseRequestedEvent(double amount, DateTime startDate, int repeatPeriod)
    {
        var plannedExpenseRequestedEvent = new PlannedExpenseRequested
        {
            Amount = amount,
            LedgerId = Guid.NewGuid(),
            RepeatPeriod = repeatPeriod,
            RepeatCount = 1,
            RepeatMeasurement = Repetition.Days,
            StartDate = startDate
        };

        plannedExpenseRequestedEvent.Publish();
    }

    private void PublishForecastCalculationRequestedEvent(DateTime startDate, DateTime endDate)
    {
        var forecastCalculationRequestEvent = new ForecastCalculationRequested
        {
            StartDate = startDate,
            EndDate = endDate,
            StartingBalance = 0
        };

        forecastCalculationRequestEvent.Publish();
    }

    [Fact]
    public void SingleDailyPlannedTransaction_ShouldHaveCorrectNumberOfForecastsAndFinalAmount()
    {
        var context = new Context
        {
            Amount = 1,
            EndDate = new DateTime(2019, 1, 10),
            ExpectedFinalDepositAmount = 10,
            ExpectedFinalExpenseAmount = -10,
            ExpectedNumberOfForecasts = 10,
            RepeatPeriod = 1,
            RepeatStart = new DateTime(2019, 1, 1),
            StartDate = new DateTime(2019, 1, 1)
        };

        RunTests(context);
    }

    [Fact]
    public void SingleWeeklyPlannedTransaction_ShouldHaveCorrectNumberOfForecastsAndFinalAmount()
    {
        var context = new Context
        {
            Amount = 1,
            EndDate = new DateTime(2019, 1, 31),
            ExpectedFinalDepositAmount = 5,
            ExpectedFinalExpenseAmount = -5,
            ExpectedNumberOfForecasts = 31,
            RepeatPeriod = 7,
            RepeatStart = new DateTime(2019, 1, 1),
            StartDate = new DateTime(2019, 1, 1)
        };

        RunTests(context);
    }

    [Fact]
    public void SingleDailyPlannedTransactionStartingInMiddleOfRepeatWindow_ShouldHaveCorrectNumberOfForecastsAndFinalAmount()
    {
        var context = new Context
        {
            Amount = 1,
            EndDate = new DateTime(2019, 1, 10),
            ExpectedFinalDepositAmount = 10,
            ExpectedFinalExpenseAmount = -10,
            ExpectedNumberOfForecasts = 10,
            RepeatPeriod = 1,
            RepeatStart = new DateTime(2018, 12, 22),
            StartDate = new DateTime(2019, 1, 1)
        };

        RunTests(context);
    }

    [Fact]
    public void SingleEveryOtherDayPlannedTransactionStartingInMiddleOfRepeatWindow_ShouldHaveCorrectNumberOfForecastsAndFinalAmount()
    {
        var context = new Context
        {
            Amount = 1,
            EndDate = new DateTime(2019, 1, 10),
            ExpectedFinalDepositAmount = 3,
            ExpectedFinalExpenseAmount = -3,
            ExpectedNumberOfForecasts = 5,
            RepeatPeriod = 2,
            RepeatStart = new DateTime(2018, 12, 22),
            StartDate = new DateTime(2019, 1, 6)
        };

        RunTests(context);
    }

    [Fact]
    public void AutoGeneratedTests_ShouldHaveCorrectNumberOfForecastsAndFinalAmount()
    {
        const int tests = 10;
        const int forecastDayCount = 10;
        var repeatStart = new DateTime(2019, 1, 1);

        // Deposits - Daily
        for (int i = 0; i < tests; i++)
        {
            double amount = i + 1;
            int repeatPeriod = 1;
            string type = "Deposit";
            RunAutoGeneratedTest(type, amount, repeatStart, repeatPeriod, forecastDayCount);
        }

        // Deposits - Variant Periods
        for (int i = 0; i < tests; i++)
        {
            double amount = i + 1;
            int repeatPeriod = i + 1;
            string type = "Deposit";
            RunAutoGeneratedTest(type, amount, repeatStart, repeatPeriod, forecastDayCount);
        }

        // Expenses - Daily
        for (int i = 0; i < tests; i++)
        {
            double amount = i + 1;
            int repeatPeriod = 1;
            string type = "Expense";
            RunAutoGeneratedTest(type, amount, repeatStart, repeatPeriod, forecastDayCount);
        }

        // Expenses - Variant Periods
        for (int i = 0; i < tests; i++)
        {
            double amount = i + 1;
            int repeatPeriod = i + 1;
            string type = "Expense";
            RunAutoGeneratedTest(type, amount, repeatStart, repeatPeriod, forecastDayCount);
        }
    }

    private void RunAutoGeneratedTest(string type, double amount, DateTime repeatStart, int repeatPeriod, int repeatCount)
    {
        Runtime.Reset();
        new UserRequested().Publish();
        PublishPlannedTransactionCreationRequestEvent(type, amount, repeatStart, repeatPeriod, repeatCount);
        var createForecastCalculationRequested = CreateForecastCalculationRequestedEvent(repeatCount);
        createForecastCalculationRequested.Publish();
        CheckForSingleTransactionPlanResults(type, amount, repeatPeriod, repeatCount);
    }

    private void RunTests(Context context)
    {

        Runtime.Reset();
        new UserRequested().Publish();

        string plannedTransactionType;
        plannedTransactionType = "Deposit";

        AssertCorrectNumberOfForecasts(plannedTransactionType, context);
        AssertCorrectFinalForecastAmount(plannedTransactionType, context);

        plannedTransactionType = "Expense";

        AssertCorrectNumberOfForecasts(plannedTransactionType, context);
        AssertCorrectFinalForecastAmount(plannedTransactionType, context);
    }

    private void AssertCorrectNumberOfForecasts(string type, Context context)
    {
        RunTestCorrectNumberOfForecasts(type, context);
        var actual = Forecast.GetAll().Count;
        var expected = context.ExpectedNumberOfForecasts;
        Assert.Equal(expected, actual);
    }

    private void AssertCorrectFinalForecastAmount(string type, Context context)
    {
        RunTestCorrectFinalForecastAmount(type, context);
        var actual = Forecast.GetLast().Amount;
        double expected;
        if (type == "Deposit")
        {
            expected = context.ExpectedFinalDepositAmount;
        }
        else if (type == "Expense")
        {
            expected = context.ExpectedFinalExpenseAmount;
        }
        else
        {
            throw new ArgumentException("Invalid planned transaction type.");
        }

        Assert.Equal(expected, actual);
    }

    private void RunTestCorrectNumberOfForecasts(string type, Context context)
    {
        RunTest(type, context);
        var actual = Forecast.GetAll().Count;
        var expected = context.ExpectedNumberOfForecasts;
        Assert.Equal(expected, actual);
    }

    private void RunTestCorrectFinalForecastAmount(string type, Context context)
    {
        RunTest(type, context);
        var actual = Forecast.GetLast().Amount;
        double expected;
        if (type == "Deposit")
        {
            expected = context.ExpectedFinalDepositAmount;
        }
        else if (type == "Expense")
        {
            expected = context.ExpectedFinalExpenseAmount;
        }
        else
        {
            throw new ArgumentException("Invalid planned transaction type.");
        }

        Assert.Equal(expected, actual);
    }

    private void RunTest(string type, Context context)
    {
        var amount = context.Amount;
        var repeatStart = context.RepeatStart;
        var repeatPeriod = context.RepeatPeriod;
        var startDate = context.StartDate;
        var endDate = context.EndDate;

        if (type == "Deposit")
        {
            ActWithSingleDeposit(amount, repeatStart, repeatPeriod, startDate, endDate);
        }
        else if (type == "Expense")
        {
            ActWithSingleExpense(amount, repeatStart, repeatPeriod, startDate, endDate);
        }
        else
        {
            throw new ArgumentException("Invalid planned transaction type.");
        }
    }
}
