using CEGES_Core;
using System.Collections.Generic;

namespace CEGES_Core.ViewModels
{
    public class DetailEntrepriseVM
    {
        public Entreprise Entreprise { get; set; }
        public List<ListeGroupesVM> Groupes { get; set; }
        public List<ApplicationUser> Analystes { get; set; }
    }
}
