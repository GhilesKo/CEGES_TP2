using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CEGES_Core.DTOs
{
	public class EquipementDetailsVM
	{
		public string Nom { get; set; }
		public string Groupe { get; set; }

		public string Type { get; set; }

		public decimal Emission { get; set; }

		public decimal EmissionAnterieure { get; set; }

		public decimal Pourcentage { get; set; }


	}
}
