using ExpenseTracker.DataAccess.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTracker.Application.Services
{
	public class TokenService : ITokenService
	{
		private readonly UserManager<AppUserEntity> _userManager;
		private readonly IConfiguration _config;

		public TokenService(UserManager<AppUserEntity> userManager, IConfiguration config)
		{
			_userManager = userManager;
			_config = config;
		}

		public string GenerateToken(AppUserEntity user)
		{
			var tokenHandler = new JwtSecurityTokenHandler();

			var key = Encoding.ASCII.GetBytes(_config.GetSection("JWT")
				.GetSection("SecurityKey").Value!);

			var Roles = _userManager.GetRolesAsync(user).Result;

			List<Claim> claims =
				[
					new Claim(JwtRegisteredClaimNames.Email, user.Email ?? ""),
					new(JwtRegisteredClaimNames.NameId, user.Id ?? ""),
					new Claim("firstName", user.FirstName ?? ""),
					new Claim("lastName", user.LastName ?? ""),
					new(JwtRegisteredClaimNames.Aud, _config.GetSection("JWT")
					.GetSection("ValidAudience").Value!),
					new(JwtRegisteredClaimNames.Iss, _config.GetSection("JWT")
					.GetSection("ValidIssuer").Value!)
				];

			foreach (var role in Roles)
			{
				claims.Add(new Claim(ClaimTypes.Role, role));
			}

			var tokenDescriptor = new SecurityTokenDescriptor
			{
				Subject = new ClaimsIdentity(claims),
				Expires = DateTime.UtcNow.AddMinutes(5),
				SigningCredentials = new SigningCredentials(
					new SymmetricSecurityKey(key),
					SecurityAlgorithms.HmacSha256
				)
			};

			var token = tokenHandler.CreateToken(tokenDescriptor);

			return tokenHandler.WriteToken(token);


		}


	}
}
