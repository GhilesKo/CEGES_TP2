using CEGES_Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CEGES_Core.ViewModels
{
	public class EntrepriseSommaireAvecVariationVM
	{
		public string Nom { get; init; }

		public decimal Total { get; set; }

		public decimal TotalPeriodeAnterieure { get; set; }

		public IEnumerable<GroupeSommaire> Groupes { get; set; }
	}
}
