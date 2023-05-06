using ErrorOr;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace PetAdoptionApp.SharedKernel.ErrorHandling;

[Route("api/[controller]")]
[ApiController]
public abstract class ApiControllerBase : ControllerBase
{
    protected IActionResult Problem(List<Error> errors)
    {
        if (errors.Count == 0)
            return Problem();

        if (errors.All(e => e.Type == ErrorType.Validation))
            return ValidationProblem(errors);

        HttpContext.Items[HttpContextItemKeys.Errors] = errors;

        return Problem(errors[0]);
    }

    private IActionResult Problem(Error firstError)
    {
        // Implement switch by firstError.Code if necessary
        var statusCode = firstError.Type switch
        {
            ErrorType.Conflict => StatusCodes.Status409Conflict,
            ErrorType.Validation => StatusCodes.Status400BadRequest,
            ErrorType.NotFound => StatusCodes.Status404NotFound,
            _ => StatusCodes.Status500InternalServerError
        };

        return Problem(statusCode: statusCode, title: firstError.Description);
    }

    private IActionResult ValidationProblem(List<Error> errors)
    {
        var modelStateDict = new ModelStateDictionary();
        foreach (var error in errors)
            modelStateDict.AddModelError(error.Code, error.Description);

        return ValidationProblem(modelStateDict);
    }
}
