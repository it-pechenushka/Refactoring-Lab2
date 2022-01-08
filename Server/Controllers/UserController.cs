using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Dto;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Server.Services;

namespace Server.Controllers
{
	[Route("api/v1/users")]
	public class UserController : BaseAuthenticatedController
	{
		private readonly IUserService _userService;

		public UserController(IUserService userService)
		{
			_userService = userService;
		}

		[Route("new")]
		[HttpPost]
		public async Task<IActionResult> AddUser([FromBody] RegisterDto registerDto)
		{
			if (registerDto == null)
				return BadRequest("Bad register info");

			try
			{
				await _userService.CreateUser(registerDto);
				await Authenticate(registerDto.Name);
			}
			catch (Exception e)
			{
				return BadRequest(e.Message);
			}

			return Ok();
		}

		[Route("login")]
		[HttpPost]
		public async Task<IActionResult> Login([FromBody] RegisterDto registerDto)
		{
			if (registerDto == null)
				return BadRequest("Bad login info");

			try
			{
				if (_userService.GetUserByName(registerDto.Name) == null)
				{
					return NotFound($"No such user '{registerDto.Name}'");
				}
			}
			catch (Exception e)
			{
				return NotFound($"No such user '{registerDto.Name}'");
			}

			if (_userService.CompareUserPassword(registerDto.Name, registerDto.Password))
			{
				await Authenticate(registerDto.Name);
			}
			else
			{
				return Unauthorized("Wrong password");
			}

			return Ok();
		}

		[Route("logout")]
		[HttpPost]
		public async Task Logout()
		{
			CheckCredentials();
			await HttpContext.SignOutAsync();
		}

		protected async Task Authenticate(string userName)
		{
			var claims = new List<Claim>
			{
				new Claim(ClaimsIdentity.DefaultNameClaimType, userName)
			};
			ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType,
				ClaimsIdentity.DefaultRoleClaimType);
			await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
		}
	}
}
