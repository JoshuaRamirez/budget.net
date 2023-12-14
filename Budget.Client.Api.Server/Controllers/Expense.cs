using Budget.Application.Events.Requested.Creation;
using Microsoft.AspNetCore.Mvc;

namespace Budget.Client.Api.Server.Controllers
{
    public class Expense : Controller
    {
        public IActionResult Post(ExpenseRequested expenseRequested)
        {
            expenseRequested.Publish();
            return Ok();
        }
    }
}
