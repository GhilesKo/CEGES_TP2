using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CEGES_Core.DTOs
{
	public class EntrepriseDetailsVM
	{

		public string Nom { get; set; }

		public decimal Total { get; set; }

		public IEnumerable<EquipementDetails> Equipements { get; set; }


	}
}
