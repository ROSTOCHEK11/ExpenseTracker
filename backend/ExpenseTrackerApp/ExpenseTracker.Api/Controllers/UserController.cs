using ExpenseTracker.Application.Services;
using ExpenseTracker.DataAccess.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseTracker.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class UserController : ControllerBase
	{
		private readonly UserAuthService _userAuthService;

		public UserController(UserAuthService userAuthService)
        {
			_userAuthService = userAuthService;
		}

        // route/register
        [HttpPost("register")]
		public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
		{
			if(!ModelState.IsValid)
				return BadRequest(ModelState);

			var result = await _userAuthService.RegisterAsync(registerDto);

			if (result.IsSucceed)
			{
				return Ok(result);
			}
			else
			{
				return BadRequest(result);
			}
				
		}
		
	}
}
