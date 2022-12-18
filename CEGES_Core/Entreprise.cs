using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CEGES_Core
{
    public class Entreprise
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public List<Groupe> Groupes { get; set; }
        public List<Periode> Periodes { get; set; }
        [NotMapped]
        public int GroupesCount { get; set; }
        [NotMapped]
        public int EquipementsCount { get; set; }
        [NotMapped]
        public int PeriodesCount { get; set; }
        public List<ApplicationUser> Analystes { get; set; }
    }
}
