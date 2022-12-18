using CEGES_Core;
using CEGES_Core.IRepository;
using CEGES_Core.ViewModels;
using CEGES_Services.IServices;
using CEGES_Util;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace CEGES_MVC.Areas.Analyse.Controllers
{
    [Area("Analyse")]
    [Authorize(Roles = $"{AppConstants.IngenieurRole},{AppConstants.AnalysteRole}")]
    public class PeriodeController : Controller
    {
        private readonly ICegesServices _services;
        private readonly UserManager<IdentityUser> _userManager;

        public PeriodeController(ICegesServices services, UserManager<IdentityUser> userManager)
        {
            _services = services;
            _userManager = userManager;
        }

        //Entreprises
        public async Task<IActionResult> IndexAsync()
        {

            var user = await _userManager.GetUserAsync(HttpContext.User);



            List<ListeEntreprisesVM> vm = _services.Configuration.GetEntreprisesAndCountsAsync();

            if (await _userManager.IsInRoleAsync(user, AppConstants.AnalysteRole))
            {
                foreach (var entreprise in vm)
                {
                    foreach (var item in collection)
                    {

                    }
                }

            }

            return View(vm);
        }


        //Periodes
        public async Task<IActionResult> Liste(int id)
        {

            ListePeriodesVM vm = await _services.Analyse.GetListePeriodes(id);
            return View(vm);
        }

        public async Task<IActionResult> Details(int entrepriseId, int periodeId)
        {
            ListeMesuresVM vm = await _services.Analyse.GetPeriodeDetails(entrepriseId, periodeId);
            return View(vm);
        }

        public async Task<IActionResult> Insert(int entrepriseId, DateTime periodeDebut)
        {
            ListeMesuresVM vm = await _services.Analyse.NewPeriodeAsync(entrepriseId, periodeDebut);
            return View("Upsert", vm);
        }


        public async Task<IActionResult> Update(int entrepriseId, int periodeId)
        {
            ListeMesuresVM vm = await _services.Analyse.GetPeriodeDetails(entrepriseId, periodeId);
            return View("Upsert", vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upsert(ListeMesuresVM vm)
        {
            if (ModelState.IsValid)
            {
                Periode periode = await _services.Analyse.UpsertPeriodeAsync(vm);

                return RedirectToAction(nameof(Details), new
                {
                    EntrepriseId = vm.EntrepriseId,
                    periodeId = periode.Id
                });
            }
            if (vm.EntrepriseId > 0)
            {
                return View(nameof(Liste), new { id = vm.EntrepriseId });
            }
            else
            {
                return View(nameof(IndexAsync));
            }
        }
    }
}
