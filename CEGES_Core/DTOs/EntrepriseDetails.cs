using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CEGES_Core.DTOs
{
	public class EntrepriseDetails
	{

		public string Nom { get; set; }

		public decimal EmissionTotal { get; set; }

		public IEnumerable<EquipementDetails> Equipements { get; set; }


	}
}
