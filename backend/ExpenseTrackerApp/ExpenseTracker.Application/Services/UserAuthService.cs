using ExpenseTracker.Core.Models;
using ExpenseTracker.Core.Types;
using ExpenseTracker.DataAccess.DTOs;
using ExpenseTracker.DataAccess.Entities;
using ExpenseTracker.DataAccess.Repositories;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTracker.Application.Services
{
	public class UserAuthService : IUserAuthService
	{
		private readonly UserManager<AppUserEntity> _userManager;

		public UserAuthService(UserManager<AppUserEntity> userManager)
		{
			_userManager = userManager;
		}

		public async Task<AuthResponseDto> RegisterAsync(RegisterDto registerDto)
		{

			if (string.IsNullOrEmpty(registerDto.Email) || string.IsNullOrEmpty(registerDto.Password))
			{
				return new AuthResponseDto { IsSucceed = false, Message = "Missing Email or Password." };
			}

			var userExists = await _userManager.FindByEmailAsync(registerDto.Email);
			if (userExists != null)
			{
				return new AuthResponseDto { IsSucceed = false, Message = "User already exists." };
			}


			AppUserEntity user = new()
			{
				FirstName = registerDto.FirstName,
				LastName = registerDto.LastName,
				Email = registerDto.Email,
				UserName = registerDto.Email
			};

			var result = await _userManager.CreateAsync(user, registerDto.Password);

			if (!result.Succeeded)
			{
				string errorString = "User Creation Failed : ";
				foreach (var error in result.Errors)
				{
					errorString += " * " + error.Description;
				}
				return new AuthResponseDto()
				{
					IsSucceed = false,
					Message = errorString
				};
			}

			if (registerDto.Roles is null)
			{
				await _userManager.AddToRoleAsync(user, RoleType.User);
			}
			else
			{
				foreach (var role in registerDto.Roles)
				{
					await _userManager.AddToRoleAsync(user, role);
				}
			}

			return new AuthResponseDto()
			{
				IsSucceed = true,
				Message = "User created Successfully"
			};

		}

		public async Task<AuthResponseDto> LoginAsync(LoginDto loginDto)
		{

			var user = await _userManager.FindByEmailAsync(loginDto.Email);

			if(user is null)
			{
				return new AuthResponseDto()
				{
					IsSucceed = false,
					Message = "User with this Email is not found!"
				};
			}

			var isPasswordCorrect = await _userManager.CheckPasswordAsync(user, loginDto.Password);

			if (!isPasswordCorrect)
			{
				return new AuthResponseDto
				{
					IsSucceed = false,
					Message = "Invalid Password"
				};
			}

			return new AuthResponseDto()
			{
				IsSucceed = true,
				Message = "Login Success"
			};
		}


	}
}
