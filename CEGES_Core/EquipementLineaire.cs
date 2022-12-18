using CEGES_Util;
using System;
using System.ComponentModel.DataAnnotations;

namespace CEGES_Core
{
    public class EquipementLineaire : Equipement
    {
        public override EquipementType Type { get; protected set; } = EquipementType.Lineaire;

        /// <summary>
        /// Unité de mesure du facteur de conversion pour obtenir des tonnes par jour
        /// </summary>

        /// <summary>
        /// Facteur de conversion permettant d'obtenir des tonnes par jour à partir de la mesure fournie pour la période
        /// </summary>
        [DisplayFormat(DataFormatString = "{0:0.##########}", ApplyFormatInEditMode = true)]
        public decimal FacteurConversion { get; set; }
        public string UniteMesure { get; set; }

        public override decimal EmissionsMensuelles(int jours, Decimal mesure)
        {
            return FacteurConversion * mesure;
        }

        public override string Formule(int jours, Decimal mesure)
        {
            return $"{FacteurConversion.RoundToSignificantDigits(3)} t / {UniteMesure} × {mesure.RoundToSignificantDigits(3)} {UniteMesure}";
        }

        public override string GetUniteMesure() => UniteMesure;
    }
}
