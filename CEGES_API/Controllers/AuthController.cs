using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using CEGES_Core;
using Microsoft.AspNetCore.Authorization;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using CEGES_Util;

namespace CEGES_API.Controllers
{
	[Authorize(Roles = $"{AppConstants.AnalysteRole}")]
	[ApiController]
	[Route("[controller]")]
	public class AuthController : ControllerBase
	{


		private readonly ILogger<AuthController> _logger;
		private readonly UserManager<ApplicationUser> _userManager;
		private readonly RoleManager<IdentityRole> _roleManager;
		private readonly IConfiguration _configuration;

		public AuthController(ILogger<AuthController> logger, UserManager<ApplicationUser> userManager, IConfiguration configuration, RoleManager<IdentityRole> roleManager)
		{
			_logger = logger;
			_userManager = userManager;
			_configuration = configuration;
			_roleManager = roleManager;
		}

		[AllowAnonymous]
		[HttpPost("signin")]
		public async Task<IActionResult> SignInAsync([FromBody] SignInRequest signInRequest)
		{
			//Basic JWT based authentication:
			//https://www.c-sharpcorner.com/article/jwt-authentication-and-authorization-in-net-6-0-with-identity-framework/

			var user = await _userManager.FindByEmailAsync(signInRequest.Email);


			if (user != null && await _userManager.CheckPasswordAsync(user, signInRequest.Password))
			{
				var userRoles = await _userManager.GetRolesAsync(user);

				var authClaims = new List<Claim>
				{
					new Claim(ClaimTypes.NameIdentifier, user.Id),
					new Claim(ClaimTypes.Name, user.Email),
					new Claim(ClaimTypes.Email, user.Email),
					new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
				};

				foreach (var userRole in userRoles)
				{
					authClaims.Add(new Claim(ClaimTypes.Role, userRole));
				}

				var token = GetToken(authClaims);

				return Ok(new
				{
					token = new JwtSecurityTokenHandler().WriteToken(token),
					expiration = token.ValidTo
				});
			}

			return Unauthorized();
		}

		[HttpGet("claims")]
		public IActionResult GetClaims()
		{
			return Ok(User.Claims.Select(c => c.Value));
		}
		private JwtSecurityToken GetToken(List<Claim> authClaims)
		{
			var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

			var token = new JwtSecurityToken(
				issuer: _configuration["JWT:ValidIssuer"],
				audience: _configuration["JWT:ValidAudience"],
				expires: DateTime.Now.AddHours(10),
				claims: authClaims,
				signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
				);

			return token;
		}

		public record SignInRequest(string Email, string Password);
		public record RegisterRequest(string Email, string Name, string Password);
	}
}