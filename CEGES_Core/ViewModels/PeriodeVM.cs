using CEGES_Core;
using System;
using System.Collections.Generic;

namespace CEGES_Core.ViewModels
{
    public class PeriodeVM
    {
        //public Dictionary<int, List<Periode>> Periodes { get; set; }
        //public Entreprise Entreprise { get; set; }

		public int Id { get; set; }
		public string Nom { get; set; }
		public DateTime Debut { get; set; }
		public DateTime Fin { get; set; }
	}
}
