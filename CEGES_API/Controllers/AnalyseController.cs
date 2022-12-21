using CEGES_Core.ViewModels;
using CEGES_Core;
using CEGES_Services.IServices;
using CEGES_Util;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace CEGES_API.Controllers
{
	[Authorize(Roles = $"{AppConstants.AnalysteRole}")]
	[Route("[controller]")]
	[ApiController]
	public class AnalyseController : ControllerBase
	{
		private readonly ICegesServices _services;
		private readonly UserManager<ApplicationUser> _userManager;

		public AnalyseController(ICegesServices services, UserManager<ApplicationUser> userManager)
		{
			_services = services;
			_userManager = userManager;
		}


		[HttpGet("entreprises")]
		public async Task<IActionResult> AnalysteEntreprisesAndCount()
		{

			var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

			
			var user = await _userManager.GetUserAsync(User);

			List<ListeEntreprisesVM> vm;

			//check if user is an ANALYSTE
			if (await _userManager.IsInRoleAsync(user, AppConstants.AnalysteRole))
			{

				//return only the entreprises he belongs 
				vm = _services.Configuration.GetAnalysteEntreprisesAndCountsAsync(userId);
				return Ok(vm);

			}

			//user is a INGENIEUR, returns all entreprises
			vm = _services.Configuration.GetEntreprisesAndCountsAsync();

			return Ok(vm);
		}


		[HttpGet("{entrepriseId}/sommaire")]
		public async Task<IActionResult> StatistiquesSommaireEntreprise(int entrepriseId)
		{

			//
			var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);


			//Check if analyste has access to that entreprise
			//var entreprisesAnalyste = _services.Configuration.GetAnalysteEntreprisesAndCountsAsync(userId).Select(e => e.Id);

			//if (!entreprisesAnalyste.Any(c => c == entrepriseId))
			//{
			//	return Unauthorized();
			//}


			var vm = await _services.Analyse.GetEntrepriseStatistiquesSommaire(entrepriseId);

			return Ok(vm);
		}


		[HttpGet("{entrepriseId}/details")]
		public async Task<IActionResult> StatistiquesDetaillesEntreprise(int entrepriseId)
		{

			var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
			var user = await _userManager.GetUserAsync(User);

			return Ok();
		}
	}
}
