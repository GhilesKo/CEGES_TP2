using CEGES_Util;
using System;
using System.ComponentModel.DataAnnotations;

namespace CEGES_Core
{
    public class EquipementConstant : Equipement
    {
        public override EquipementType Type { get; protected set; } = EquipementType.Constant;

        /// <summary>
        /// Émissions quotidiennes de l'équipement en tonnes/jour
        /// </summary>
        [DisplayFormat(DataFormatString = "{0:0.##########}", ApplyFormatInEditMode = true)]
        public decimal Emissions { get; set; }

        public override decimal EmissionsMensuelles(int jours, decimal mesure)
        {
            return Emissions * jours;
        }

        public override string Formule(int jours, Decimal mesure)
        {
            return $"{Emissions.RoundToSignificantDigits(3)} t / j × {jours} j";
        }

        public override string GetUniteMesure() => "t / j";

    }
}
