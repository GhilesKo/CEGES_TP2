using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using CEGES_DataAccess.Data;
using CEGES_Core;
using CEGES_Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CEGES_DataAccess.Initializer
{
    public class DbInitializer : IDbInitializer
    {
        private readonly CegesDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public DbInitializer(CegesDbContext db, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _db = db;
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public void Initialize()
        {

            try
            {
                if (_db.Database.GetPendingMigrations().Count() > 0)
                {
                    _db.Database.Migrate();
                }
            }
            catch (Exception)
            {

            }


            if (!_roleManager.RoleExistsAsync(AppConstants.IngenieurRole).GetAwaiter().GetResult())
            {
                _roleManager.CreateAsync(new IdentityRole(AppConstants.IngenieurRole)).GetAwaiter().GetResult();
                _roleManager.CreateAsync(new IdentityRole(AppConstants.AnalysteRole)).GetAwaiter().GetResult();
            }
            else
            {
                return;
            }

            // Modifier pour refléter les modifications à ApplicationUser avant de mettre en application
            _userManager.CreateAsync(new ApplicationUser
            {

                UserName = "SuperIngenieur@Ceges.ca",
                Email = "SuperIngenieur@Ceges.ca",
                EmailConfirmed = true,
                PhoneNumber = "111111111111"
            }, "Ceges1234*")
                      .GetAwaiter()
                      .GetResult();

            ApplicationUser user = _db.ApplicationUsers.FirstOrDefault(u => u.Email == "SuperIngenieur@Ceges.ca");
            _userManager.AddToRoleAsync(user, AppConstants.IngenieurRole).GetAwaiter().GetResult();









            _userManager.CreateAsync(new ApplicationUser
            {
                UserName = "AnalystePizzaPizza@Ceges.ca",
                Email = "AnalystePizzaPizza@Ceges.ca",
                EmailConfirmed = true,
                PhoneNumber = "111111111111"
            }, "Ceges1234*")
                .GetAwaiter()
                .GetResult();

            ApplicationUser user2 = _db.ApplicationUsers.FirstOrDefault(u => u.Email == "AnalystePizzaPizza@Ceges.ca");
            _userManager.AddToRoleAsync(user2, AppConstants.AnalysteRole).GetAwaiter().GetResult();


            _userManager.CreateAsync(new ApplicationUser
            {
                UserName = "AnalysteAluminiumQc@Ceges.ca",
                Email = "AnalysteAluminiumQc@Ceges.ca",
                EmailConfirmed = true,
                PhoneNumber = "111111111111"
            }, "Ceges1234*")
                .GetAwaiter()
                .GetResult();

            ApplicationUser user3 = _db.ApplicationUsers.FirstOrDefault(u => u.Email == "AnalysteAluminiumQc@Ceges.ca");
            _userManager.AddToRoleAsync(user3, AppConstants.AnalysteRole).GetAwaiter().GetResult();
        }


    }
}
