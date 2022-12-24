using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CEGES_Core.DTOs
{
	public class EntrepriseDetailsAvecVariation
	{
		public string Nom { get; set; }

		public IEnumerable<EmissionTotal> EmissionsTotal { get; set; }

		public IEnumerable<EquipementDetails> Equipements { get; set; }


	}

	public class EmissionTotal
	{
		public int PeriodeId { get; set; }
		public decimal Total { get; set;}
	}
}
