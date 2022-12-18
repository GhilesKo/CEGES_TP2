using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CEGES_Core.ViewModels
{
    public class UserIncludeEntreprisesVM
    {
        public ApplicationUser User { get; set; }

        public List<ListeEntreprisesVM> EntreprisesVMs { get; set; }
    }
}
