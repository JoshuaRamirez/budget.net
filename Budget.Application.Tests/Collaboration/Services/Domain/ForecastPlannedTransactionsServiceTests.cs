﻿using System;
using Xunit;
using Budget.Application.Projections;
using Budget.Application.Events.Requested.Creation;
using Budget.Application.Events.Requested.Calculation;
using Budget.Application;
using Budget.Application.Projections.Core;
using System.Linq;

public class ForecastPlannedTransactionsServiceTests
{

    public struct Context
    {
        public int TransactionAmount { get; set; }
        public DateTime EndDate { get; set; }
        public int ExpectedFinalDepositAmount { get; set; }
        public int ExpectedFinalExpenseAmount { get; set; }
        public int ExpectedNumberOfForecasts { get; set; }
        public int RepeatPeriod { get; set; }
        public DateTime RepeatStart { get; set; }
        public DateTime StartDate { get; set; }
        public int RepeatCount { get; set; }
        public Period PeriodMeasurement {  get; set; }
    }

    [Fact]
    public void SingleDailyPlannedTransaction_ShouldHaveCorrectNumberOfForecastsAndFinalAmount()
    {
        var context = new Context
        {
            TransactionAmount = 1,
            ExpectedFinalDepositAmount = 10,
            ExpectedFinalExpenseAmount = -10,
            ExpectedNumberOfForecasts = 10,
            RepeatPeriod = 1,
            RepeatCount = 10,
            RepeatStart = new DateTime(2019, 1, 1),
            StartDate = new DateTime(2019, 1, 1),
            EndDate = new DateTime(2019, 1, 10),
        };

        runTests(context);
    }

    [Fact]
    public void SingleWeeklyPlannedTransaction_ShouldHaveCorrectNumberOfForecastsAndFinalAmount()
    {
        var context = new Context
        {
            TransactionAmount = 1,
            EndDate = new DateTime(2019, 1, 31),
            ExpectedFinalDepositAmount = 5,
            ExpectedFinalExpenseAmount = -5,
            ExpectedNumberOfForecasts = 31,
            RepeatPeriod = 7,
            RepeatStart = new DateTime(2019, 1, 1),
            StartDate = new DateTime(2019, 1, 1)
        };

        runTests(context);
    }

    [Fact]
    public void SingleDailyPlannedTransactionStartingInMiddleOfRepeatWindow_ShouldHaveCorrectNumberOfForecastsAndFinalAmount()
    {
        var context = new Context
        {
            TransactionAmount = 1,
            EndDate = new DateTime(2019, 1, 10),
            ExpectedFinalDepositAmount = 10,
            ExpectedFinalExpenseAmount = -10,
            ExpectedNumberOfForecasts = 10,
            RepeatPeriod = 1,
            RepeatStart = new DateTime(2018, 12, 22),
            StartDate = new DateTime(2019, 1, 1)
        };

        runTests(context);
    }

    [Fact]
    public void SingleEveryOtherDayPlannedTransactionStartingInMiddleOfRepeatWindow_ShouldHaveCorrectNumberOfForecastsAndFinalAmount()
    {
        var context = new Context
        {
            TransactionAmount = 1,
            EndDate = new DateTime(2019, 1, 10),
            ExpectedFinalDepositAmount = 3,
            ExpectedFinalExpenseAmount = -3,
            ExpectedNumberOfForecasts = 5,
            RepeatPeriod = 2,
            RepeatStart = new DateTime(2018, 12, 22),
            StartDate = new DateTime(2019, 1, 6)
        };

        runTests(context);
    }

    [Fact]
    public void AutoGeneratedTests_ShouldHaveCorrectNumberOfForecastsAndFinalAmount()
    {
        const int tests = 10;
        var context = new Context();
        context.RepeatCount = 10;
        context.RepeatStart = new DateTime(2019, 1, 1);
        context.RepeatPeriod = 1;
        context.ExpectedNumberOfForecasts = 10;
        context.StartDate = context.RepeatStart;
        context.EndDate = context.StartDate.AddDays((context.RepeatCount * context.RepeatPeriod)-1);

        // Deposits - Daily
        for (int i = 0; i < tests; i++)
        {
            context.TransactionAmount = i + 1;    
            runAutoGeneratedTest(context, TransactionType.Deposit);
        }

        // Expenses - Daily
        for (int i = 0; i < tests; i++)
        {
            context.TransactionAmount = i + 1;
            runAutoGeneratedTest(context, TransactionType.Expense);
        }

        // Deposits - Variant Periods
        for (int i = 0; i < tests; i++)
        {
            context.TransactionAmount = i + 1;
            context.RepeatPeriod = i + 1;
            runAutoGeneratedTest(context, TransactionType.Deposit);
        }

        // Expenses - Variant Periods
        for (int i = 0; i < tests; i++)
        {
            context.TransactionAmount = i + 1;
            context.RepeatPeriod = i + 1;
            runAutoGeneratedTest(context, TransactionType.Expense);
        }
    }


    private void runTests(Context context)
    {
        runTest(context, TransactionType.Expense);
        runTest(context, TransactionType.Deposit);
    }

    private void runTest(Context context, TransactionType type)
    {
        Runtime.Reset();
        performForecast(type, context);
        assertCorrectNumberOfForecasts(type, context);
        assertCorrectFinalForecastAmount(type, context);
    }

    private void assertCorrectNumberOfForecasts(TransactionType type, Context context)
    {
        var actual = Forecast.GetAll().Count;
        var expected = context.ExpectedNumberOfForecasts;
        Assert.Equal(expected, actual);
    }

    private void assertCorrectFinalForecastAmount(TransactionType type, Context context)
    {
        var actual = Forecast.GetLast().Amount;
        double expected;
        if (type == TransactionType.Deposit)
        {
            expected = context.ExpectedFinalDepositAmount;
        }
        else if (type == TransactionType.Expense)
        {
            expected = context.ExpectedFinalExpenseAmount;
        }
        else
        {
            throw new ArgumentException("Invalid planned transaction type.");
        }
        Assert.Equal(expected, actual);
    }

    private void performForecast(TransactionType type, Context context)
    {
        if (type == TransactionType.Deposit)
        {
            publishPlannedTransactionRequestedEvent(context, TransactionType.Deposit);
            publishForecastCalculationRequestedEvent(context);
        }
        else if (type == TransactionType.Expense)
        {
            publishPlannedTransactionRequestedEvent(context, TransactionType.Expense);
            publishForecastCalculationRequestedEvent(context);
        }
        else
        {
            throw new ArgumentException("Invalid planned transaction type.");
        }
    }

    private void runAutoGeneratedTest(Context context, TransactionType type)
    {
        Runtime.Reset();
        publishPlannedTransactionCreationRequestEvent(context, type);
        publishForecastCalculationRequestedEvent(context);
        assertAutoGeneratedTestResults(context, type);
    }

    private void publishPlannedTransactionCreationRequestEvent(Context context, TransactionType transactionType)
    {
        var plannedTransactionRequested = new PlannedTransactionRequested
        {
            Amount = context.TransactionAmount,
            LedgerId = Ledger.Projections[0].Id,
            RepeatCount = context.RepeatCount,
            RepeatPeriod = context.RepeatPeriod,
            StartDate = context.RepeatStart,
            RepeatMeasurement = context.PeriodMeasurement,
            TransactionType = transactionType,
        };
        plannedTransactionRequested.Publish();
    }

    private void assertAutoGeneratedTestResults(Context context, TransactionType type)
    {
        var startDate = new DateTime(2019, 1, 1);
        var forecastProjections = Forecast.GetAll();

        Assert.Equal(context.RepeatCount, forecastProjections.Count);

        var thisDate = new DateTime(startDate.Ticks);
        var amountTotal = Math.Ceiling((double)context.RepeatCount / context.RepeatPeriod) * context.TransactionAmount;
        if (type == TransactionType.Expense)
        {
            amountTotal = -amountTotal;
        }
        Assert.Equal(amountTotal, forecastProjections.Last().Amount);

        for (var i = 0; i < forecastProjections.Count; i++)
        {
            var forecastProjection = forecastProjections[i];
            Assert.Equal(thisDate, forecastProjection.Date);
            thisDate = thisDate.AddDays(1);
        }
    }

    private void publishPlannedTransactionRequestedEvent(Context context, TransactionType type)
    {
        var @event = new PlannedTransactionRequested
        {
            Amount = context.TransactionAmount,
            LedgerId = Guid.NewGuid(),
            RepeatPeriod = context.RepeatPeriod,
            RepeatCount = context.RepeatCount,
            RepeatMeasurement = Period.Days,
            StartDate = context.StartDate,
            TransactionType = type
        };

        @event.Publish();
    }

    private void publishForecastCalculationRequestedEvent(Context context)
    {
        var forecastCalculationRequestEvent = new ForecastCalculationRequested
        {
            StartDate = context.StartDate,
            EndDate = context.EndDate,
            StartingBalance = 0
        };
        forecastCalculationRequestEvent.Publish();
    }

}
