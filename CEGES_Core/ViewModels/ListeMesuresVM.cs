using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CEGES_Core.ViewModels
{
    public class ListeMesuresVM
    {
        public int EntrepriseId { get; set; }
        public string EntrepriseNom { get; set; }
        public int PeriodeId { get; set; }
        public string PeriodeNom { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime PeriodeDebut { get; set; }
        public List<DetailMesureVM> Mesures { get; set; } = new();
    }
}
