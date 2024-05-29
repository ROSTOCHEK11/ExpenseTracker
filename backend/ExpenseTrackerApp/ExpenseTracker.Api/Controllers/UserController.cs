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
		private readonly IUserAuthService _userAuthService;

		public UserController(IUserAuthService userAuthService)
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


		// route/login
		[HttpPost("login")]
		public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			var loginResult = await _userAuthService.LoginAsync(loginDto);

			if (loginResult.IsSucceed)
			{
				return Ok(loginResult);
			}
			else
			{
				return Unauthorized(loginResult);
			}

			
		}








	}
}
