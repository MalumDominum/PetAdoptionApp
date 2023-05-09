using Microsoft.AspNetCore.Mvc;
using PetAdoptionApp.SharedKernel.ErrorHandling;

namespace AuthProvider.Api.Controllers;

[Route("AuthProvider/[controller]")]
public class UsersController : ApiControllerBase
{
	//private readonly IUsersService _service;
	//
	//public UsersController(IUsersService service) => _service = service;
	//
	//[HttpGet]
	//public async Task<ActionResult<List<UserInfoDTO>>> GetUsersInfo()
	//{
	//	return Ok(await _service.GetUsersInfoAsync());
	//}
	//
	//// GET: api/Users/3
	//[HttpGet("{userId:int}")]
	//public async Task<ActionResult<UserInfoDTO>> GetUserInfoById(int userId)
	//{
	//	return Ok(await _service.GetUserInfoByIdAsync(userId));
	//}
}
