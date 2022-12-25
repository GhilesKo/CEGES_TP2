using CEGES_Core;
using CEGES_Core.ViewModels;
using CEGES_Services.IServices;
using CEGES_Util;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CEGES_MVC.Areas.Configuration.Controllers
{
    [Area("Configuration")]
    [Authorize(Roles = AppConstants.IngenieurRole)]
    public class EntrepriseController : Controller
    {
        private readonly IConfigurationServices _configService;
        private readonly IAnalyseServices _analyseService;

        //Enlevé le wrapper ICegesService, pour faciliter le mocking pour le Testing du controlleur
		public EntrepriseController(IConfigurationServices configService, IAnalyseServices analyseService)
		{
			_configService = configService;
			_analyseService = analyseService;
		}

		public IActionResult Index()
        {
            List<ListeEntreprisesVM> vm = _configService.GetEntreprisesAndCountsAsync();
            return View(vm);
        }

        public async Task<IActionResult> Details(int id)
        {
            DetailEntrepriseVM vm = await _configService.GetEntrepriseDetailAsync(id);

            if (vm.Entreprise == null)
            {
                return NotFound();
            }
            return View(vm);
        }

        // MODIFIER VIEW , NOM ET SELECT LES ANALYSTES
        public async Task<IActionResult> Upsert(int? id)
        {
            UpsertEntrepriseVM vm = new UpsertEntrepriseVM();
            if (id == null)
            {
                vm.Entreprise = new Entreprise();
            } 
            else
            {
                vm.Entreprise = await _configService.GetEntrepriseAsync(id.GetValueOrDefault());
            }
            IEnumerable<ApplicationUser> users = await _analyseService.GetAnalystesListAsync();

            vm.Analystes = users.Select(u => new SelectListItem(u.NormalizedUserName, u.Id, vm.Entreprise.Analystes.Exists(a => a.Id == u.Id))).ToList();

            if (vm.Entreprise == null)
            {
                return NotFound();
            }
            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upsert(UpsertEntrepriseVM entrepriseVM)
        {
            if (ModelState.IsValid)
            {
                if (entrepriseVM.Entreprise.Id == 0)
                {
                    await _configService.AddEntrepriseAsync(entrepriseVM.Entreprise);

                }
                else
                {
                    _configService.UpdateEntreprise(entrepriseVM.Entreprise);
                }
                if (entrepriseVM.SelectAnalystes.Count > 3)
                {
                    // Message d'erreur "TROP D'ANALYSTES SÉLECTIONNÉS
                    return RedirectToAction(nameof(Upsert), new { id = entrepriseVM.Entreprise.Id });
                }
                try
                {
                    await _configService.EditAnalystesEntrepriseAsync(entrepriseVM.Entreprise.Id, entrepriseVM.SelectAnalystes);
                }
                catch (Exception)
                {
                    return RedirectToAction(nameof(Upsert), new { id = entrepriseVM.Entreprise.Id });
                }
                return RedirectToAction(nameof(Details), new { id = entrepriseVM.Entreprise.Id });
            }
            return View(entrepriseVM);
        }
    }
}
