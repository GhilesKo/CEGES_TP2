using CEGES_Core;
using System.Collections.Generic;

namespace CEGES_Core.ViewModels
{
    public class ListePeriodesVM
    {
        public Dictionary<int, List<Periode>> Periodes { get; set; }
        public Entreprise Entreprise { get; set; }
    }
}
