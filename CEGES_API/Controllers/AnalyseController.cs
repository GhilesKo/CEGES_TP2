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


		[HttpGet("sommaire")]
		public async Task<IActionResult> StatistiquesSommaireEntreprise([FromQuery] int entrepriseId, int periodeId, bool avecVariation, string? dateOption)
		{

			var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

			////Check if analyste has access to that entreprise
			//var entreprisesAnalyste = _services.Configuration.GetAnalysteEntreprisesAndCountsAsync(userId).Select(e => e.Id);
			//if (!entreprisesAnalyste.Any(c => c == entrepriseId))
			//{
			//	return Unauthorized();
			//}


			//var periodes = await _services.Analyse.GetListePeriodesOriginal(entrepriseId);

			////Liste mesures d'UNE ENTREPRISE at UNE PERIODE Donnee
			//var mesure = periodes.Periodes.SelectMany(p => p.Value).FirstOrDefault(p => p.Id == periodeId).Mesures.ToList();

			//var dto = new
			//{
			//	Total = mesure.Sum(m => m.Valeur),
			//	Groupes = mesure.GroupBy(m => m.Equipement.Groupe.Nom).Select(o => new
			//	{
			//		Nom = o.Key,
			//		Total = o.Sum(m => m.Valeur)
			//	})

			//};





		if (avecVariation && !string.IsNullOrEmpty(dateOption))
			{
				var sommaireAvecVariation = await _services.Analyse.GetEntrepriseStatistiquesSommaireAvecVariations(entrepriseId, periodeId, dateOption);

				return Ok(sommaireAvecVariation);
			}

			var vm = await _services.Analyse.GetEntrepriseStatistiquesSommaire(entrepriseId, periodeId);
			return Ok(vm);
		}


		[HttpGet("details")]
		public async Task<IActionResult> StatistiquesDetaillesEntreprise([FromQuery] int entrepriseId, int periodeId, bool avecVariation, string? dateOption)
		{

			var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

			////Check if analyste has access to that entreprise
			//var entreprisesAnalyste = _services.Configuration.GetAnalysteEntreprisesAndCountsAsync(userId).Select(e => e.Id);
			//if (!entreprisesAnalyste.Any(c => c == entrepriseId))
			//{
			//	return Unauthorized();
			//}


			if (avecVariation && !string.IsNullOrEmpty(dateOption))
			{
				var detailsAvecVariationVM = await _services.Analyse.GetEntrepriseStatistiquesDetailsAvecVariations(entrepriseId, periodeId, dateOption);

				return Ok(detailsAvecVariationVM);
			}

			var vm = await _services.Analyse.GetEntrepriseStatistiquesDetails(entrepriseId, periodeId);
			return Ok(vm);
		}

		[HttpGet("periodes/{entrepriseId}")]
		public async Task<IActionResult> GetPeriodesEntreprise(int entrepriseId)
		{

			var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

			////Check if analyste has access to that entreprise
			//var entreprisesAnalyste = _services.Configuration.GetAnalysteEntreprisesAndCountsAsync(userId).Select(e => e.Id);
			//if (!entreprisesAnalyste.Any(c => c == entrepriseId))
			//{
			//	return Unauthorized();
			//}

			var periodesVM = await _services.Analyse.GetListePeriodes(entrepriseId);


			return Ok(periodesVM.ToList());
		}

		[HttpGet("entreprises/{entrepriseId}")]
		public async Task<IActionResult> GetEntrepriseInfo(int entrepriseId)
		{

			var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

			////Check if analyste has access to that entreprise
			//var entreprisesAnalyste = _services.Configuration.GetAnalysteEntreprisesAndCountsAsync(userId).Select(e => e.Id);
			//if (!entreprisesAnalyste.Any(c => c == entrepriseId))
			//{
			//	return Unauthorized();
			//}

			//Seulement besoin du nom, mais sinon jaurais creer un service me retournant la vm desiré, mais pour simplicité, retourne le nom seulement

			var entreprise = await _services.Configuration.GetEntrepriseAsync(entrepriseId);
				
			return Ok(new { entreprise.Id,entreprise.Nom});
		}

	}
}
