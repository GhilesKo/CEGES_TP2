using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CEGES_Core.DTOs;

namespace CEGES_Core.ViewModels
{
    public class EntrepriseDetailsVM
    {

        public string Nom { get; set; }

        public decimal Total { get; set; }

        public IEnumerable<EquipementDetailsVM> Equipements { get; set; }


    }
}
