using Microsoft.AspNetCore.Mvc;
using PetAdoptionApp.SharedKernel.ErrorHandling;
using PetProfileDomain.Domain.Aggregates.StateAggregate.Enums;

namespace PetProfileDomain.Api.Controllers;

[Route("PetDomain/[controller]")]
public class StatesController : ApiControllerBase
{
	[HttpGet]
	public IActionResult GetList() => Ok(Status.List.OrderBy(s => s.Value));
}
