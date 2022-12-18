using CEGES_Core;
using CEGES_Services.IServices;
using CEGES_Util;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace CEGES_MVC.Areas.Configuration.Controllers
{
    [Area("Configuration")]
    [Authorize(Roles = AppConstants.IngenieurRole)]

    public class GroupeController : Controller
    {
        private readonly ICegesServices _services;

        public GroupeController(ICegesServices services)
        {
            _services = services;
        }

        public async Task<IActionResult> Details(int id)
        {
            Groupe groupe = await _services.Configuration.GetGroupeDetailsAsync(id);
            if (groupe == null)
            {
                return NotFound();
            }
            return View(groupe);
        }

        public async Task<IActionResult> Insert(int id)
        {
            Groupe groupe = await _services.Configuration.NewGroupeAsync(id);
            if (groupe == null)
            {
                return NotFound();
            }
            return View("Upsert", groupe);
        }

        public async Task<IActionResult> Update(int id)
        {
            Groupe groupe = await _services.Configuration.GetGroupeEtEntrepriseAsync(id);
            if (groupe == null)
            {
                return NotFound();
            }
            return View("Upsert", groupe);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upsert(Groupe groupe)
        {
            if (ModelState.IsValid)
            {
                if (groupe.Id == 0)
                {
                    await _services.Configuration.AddGroupeAsync(groupe);
                }
                else
                {
                    _services.Configuration.UpdateGroupe(groupe);
                }
                return RedirectToAction(nameof(Details), new { id = groupe.Id });
            }
            return View(groupe);
        }
    }
}
