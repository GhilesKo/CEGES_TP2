using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;

namespace CEGES_Core
{
    public class ApplicationUser : IdentityUser
    {
        public List<Entreprise> Entreprises { get; set; } = new();
    }
}
