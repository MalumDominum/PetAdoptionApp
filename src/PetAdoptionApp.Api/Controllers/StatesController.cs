using Microsoft.AspNetCore.Mvc;
using PetAdoptionApp.Domain.Aggregates.StateAggregate.Enums;
using PetAdoptionApp.SharedKernel.ErrorHandling;

namespace PetAdoptionApp.Api.Controllers;

public class StatesController : ApiControllerBase
{
	[HttpGet]
	public Task<IActionResult> GetList() => Task.FromResult<IActionResult>(Ok(
		Status.List.OrderBy(s => s.Value)));
}
