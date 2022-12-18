using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace CEGES_Core.ViewModels
{
    public class UpsertEntrepriseVM
    {
        public Entreprise Entreprise { get; set; }
        public List<SelectListItem> Analystes { get; set; }
        public List<string> SelectAnalystes { get; set; }
    }
}
