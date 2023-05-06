using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace PetProfileDomain.Api.Controllers;

[ApiController]
[ApiExplorerSettings(IgnoreApi = true)]
public class ErrorsController : ControllerBase
{
    [Route("Error/")]
    public IActionResult Error()
    {
        var exception = HttpContext.Features.Get<IExceptionHandlerFeature>()?.Error;

        var (statusCode, message) = exception switch
        {
            _ => (StatusCodes.Status500InternalServerError, "An unexpected error occured.")
        };

        return Problem(statusCode: statusCode, title: message);
    }
}
