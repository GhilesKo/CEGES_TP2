using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CEGES_Core
{
    public abstract class Equipement
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        [NotMapped]
        public abstract EquipementType Type { get; protected set; }
        public int GroupeId { get; set; }
        public Groupe Groupe { get; set; }
        public List<Mesure> Mesures { get; set; }
        public abstract string Formule(int jours, Decimal mesure);
        public abstract decimal EmissionsMensuelles (int jours, Decimal mesure);
        public abstract string GetUniteMesure();
    }
}
