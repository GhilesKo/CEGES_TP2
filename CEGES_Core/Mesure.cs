using System;
using System.ComponentModel.DataAnnotations;

namespace CEGES_Core
{
    public class Mesure
    {
        public int Id { get; set; }
        public int EquipementId { get; set; }
        public Equipement Equipement { get; set; }
        public int PeriodeId { get; set; }
        public Periode Periode { get; set; }

        [DisplayFormat(DataFormatString = "{0:0.##########}", ApplyFormatInEditMode = true)]
        public Decimal Valeur { get; set; }
    }
}
