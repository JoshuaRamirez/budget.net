using Budget.Application.Events.Core;
using Budget.Application.Events.Requested.Creation;
using Budget.Application.Projections.Core;
using Budget.Application.Services.Creates;
using Budget.Application.Services.Domain;
using Budget.Application.Services.Links;
using Budget.Application.Services.Transformers;

namespace Budget.Application
{
    public static class Runtime
    {
        public static void Start()
        {
            ProjectionStore.Clear();
            Bus.Clear();

            //Create Services
            CreateAccountService.Instance.Subscribe();
            CreateAllocationService.Instance.Subscribe();
            CreateBudgetService.Instance.Subscribe();
            CreateCategoryService.Instance.Subscribe();
            CreateDepositService.Instance.Subscribe();
            CreateExpenseService.Instance.Subscribe();
            CreateForecastService.Instance.Subscribe();
            CreateLedgerService.Instance.Subscribe();
            CreatePayeeService.Instance.Subscribe();
            CreatePayerService.Instance.Subscribe();
            CreatePlannedDepositService.Instance.Subscribe();
            CreatePlannedExpenseService.Instance.Subscribe();
            CreatePlannedTransactionService.Instance.Subscribe();
            CreateProposedTransactionService.Instance.Subscribe();
            CreateTransactionService.Instance.Subscribe();
            CreateUserService.Instance.Subscribe();

            //Link Services
            AccountToUser.Instance.Subscribe();
            DepositToPlannedDeposit.Instance.Subscribe();
            ExpenseToPayee.Instance.Subscribe();
            ExpenseToPlannedExpense.Instance.Subscribe();
            ForecastToPlannedTransaction.Instance.Subscribe();
            LedgerToAccount.Instance.Subscribe();
            TransactionToLedger.Instance.Subscribe();
            ProposedTransactionToPlannedTransaction.Instance.Subscribe();

            //Transformer Services
            AccountCreatedToLedgerRequested.Instance.Subscribe();
            PlannedDepositCreatedToPlannedTransactionRequested.Instance.Subscribe();
            PlannedExpenseCreatedToPlannedTransactionRequested.Instance.Subscribe();
            PlannedTransactionCreatedToProposedTransactionRequested.Instance.Subscribe();
            UserCreatedToAccountRequested.Instance.Subscribe();

            //Domain Services
            ForecastPlannedTransactionsService.Instance.Subscribe();
            IncrementProposedTransactionCounterService.Instance.Subscribe();
            ProposeTransactionsForTodayService.Instance.Subscribe();
            UpdateLedgerBalanceService.Instance.Subscribe();
            UpdateLedgerStartingBalanceService.Instance.Subscribe();
        }

        public static void Stop()
        {
            Bus.Clear();
            ProjectionStore.Clear();
            //TODO: Clear Event Store
        }

        public static void Reset()
        {
            Stop();
            Start();
            new UserRequested().Publish();
        }
    }
}
