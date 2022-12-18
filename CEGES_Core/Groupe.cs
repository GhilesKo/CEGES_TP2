using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CEGES_Core
{
    public class Groupe
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public int EntrepriseId { get; set; }
        public Entreprise Entreprise { get; set; }
        public List<Equipement> Equipements { get; set; }
        [NotMapped]
        public int EquipementsCount { get; set; }
    }
}
