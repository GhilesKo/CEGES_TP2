using CEGES_Util;
using System;
using System.ComponentModel.DataAnnotations;

namespace CEGES_Core
{
    public class EquipementRelatif : Equipement
    {        
        public override EquipementType Type { get; protected set; } = EquipementType.Relatif;
        /// <summary>
        /// Valeur des émissions en tonnes/jour lors d'un usage à l'intensité minimale (0%)
        /// </summary>
        [DisplayFormat(DataFormatString = "{0:0.##########}", ApplyFormatInEditMode = true)]
        public decimal Minimum { get; set; }
        /// <summary>
        /// Valeur des émissions en tonnes/jour lors d'un usage à l'intensité maximale (100%)
        /// </summary>
        [DisplayFormat(DataFormatString = "{0:0.##########}", ApplyFormatInEditMode = true)]
        public decimal Maximum { get; set; }

        public override decimal EmissionsMensuelles(int jours, decimal mesure)
        {
            return (Maximum - Minimum) * mesure + Minimum * jours;
        }

        public override string Formule(int jours, Decimal mesure)
        {
            return $"{mesure.RoundToSignificantDigits(3)}% de [{Minimum.RoundToSignificantDigits(3)} à {Maximum.RoundToSignificantDigits(3)}] t / j × {jours} j";
        }

        public override string GetUniteMesure() => "%";
    }
}
