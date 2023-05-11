using ErrorOr;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace PetAdoptionApp.SharedKernel.ErrorHandling;

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
        var statusCode = firstError.NumericType switch
        {
	        (int)ErrorType.Conflict => StatusCodes.Status409Conflict,
	        (int)ErrorType.Validation => StatusCodes.Status400BadRequest,
	        (int)ErrorType.NotFound => StatusCodes.Status404NotFound,
			(int)ErrorType.Failure => StatusCodes.Status500InternalServerError,
	        _ => firstError.NumericType
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
