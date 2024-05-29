using ExpenseTracker.DataAccess.DTOs;

namespace ExpenseTracker.Application.Services
{
	public interface IUserAuthService
	{
		Task<AuthResponseDto> LoginAsync(LoginDto loginDto);
		Task<AuthResponseDto> RegisterAsync(RegisterDto registerDto);
	}
}