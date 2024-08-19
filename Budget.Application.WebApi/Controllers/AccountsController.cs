using Budget.Application.Events.Requested.Creation;
using Budget.Application.Services.Creates;
using Microsoft.AspNetCore.Mvc;

namespace Budget.Application.WebApi.Controllers;
[ApiController]
[Route("api/accounts")]
public class AccountsController(CreateAccountService _createAccountService) : Controller
{
    [HttpPost("create")]
    public IActionResult CreateAccount([FromBody] AccountRequested accountRequested)
    {
        if (!ModelState.IsValid)
        {
            return this.BadRequest(ModelState);
        }
        _createAccountService.Serve(accountRequested);
        return this.Ok();
    }
}