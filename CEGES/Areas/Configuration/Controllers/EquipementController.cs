using CEGES_Core;
using CEGES_Services.IServices;
using CEGES_Util;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Threading.Tasks;

namespace CEGES_MVC.Areas.Configuration.Controllers
{
    [Area("Configuration")]
    [Authorize(Roles = AppConstants.IngenieurRole)]

    public class EquipementController : Controller
    {
        private readonly ICegesServices _services;

        public EquipementController(ICegesServices services)
        {
            _services = services;
        }

        public async Task<IActionResult> Details(int id)
        {
            Equipement equipement = await _services.Configuration.GetEquipementDetailAsync(id);
            if (equipement == null)
            {
                return NotFound();
            }
            return View(equipement);
        }

        public async Task<IActionResult> InsertType(int id)
        {
            Groupe groupe = await _services.Configuration.GetGroupeAsync(id);
            if (groupe == null)
            {
                return NotFound();
            }
            return View(groupe);
        }

        public async Task<IActionResult> Insert(int id, string type)
        {
            Equipement equipement = await _services.Configuration.NewEquipementAsync(id, type);
            if (equipement == null || equipement.Groupe == null)
            {
                return NotFound();
            }
            return View("Upsert", equipement);
        }

        public async Task<IActionResult> Update(int id)
        {
            Equipement equipement = await _services.Configuration.GetEquipementDetailAsync(id);
            if (equipement == null)
            {
                return NotFound();
            }
            return View("Upsert", equipement);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upsert(Equipement equipement)
        {
            if (ModelState.IsValid)
            {
                if (equipement.Id == 0)
                {
                    await _services.Configuration.AddEquipementAsync(equipement);
                }
                else
                {
                    _services.Configuration.UpdateEquipement(equipement);
                }
                return RedirectToAction(nameof(Details), new { id = equipement.Id });
            }
            return View(equipement);

        }
    }
}
