using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace AuthProvider.Api.Controllers;

[ApiController]
[ApiExplorerSettings(IgnoreApi = true)]
[Route("AuthProvider/[controller]")]
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
