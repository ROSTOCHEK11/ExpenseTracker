using ExpenseTracker.DataAccess.Entities;

namespace ExpenseTracker.Application.Services
{
	public interface ITokenService
	{
		string GenerateToken(AppUserEntity user);
	}
}