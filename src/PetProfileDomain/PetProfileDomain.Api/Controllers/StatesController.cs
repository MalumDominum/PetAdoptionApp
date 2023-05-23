using Microsoft.AspNetCore.Mvc;
using PetAdoptionApp.SharedKernel.ErrorHandling;
using PetProfileDomain.Api.Models;
using PetProfileDomain.Domain.Aggregates.StateAggregate.Enums;

namespace PetProfileDomain.Api.Controllers;

[Route("PetDomain/[controller]")]
public class StatesController : ApiControllerBase
{
	[HttpGet]
	public IActionResult GetList() =>
		Ok(new { Results = Status.List.Select(s => 
			new StatusDto(s.Value, s.Name)).OrderBy(s => s.Id) });
}
