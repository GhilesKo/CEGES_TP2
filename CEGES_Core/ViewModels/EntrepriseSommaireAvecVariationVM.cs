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
		public string Nom { get; set; }

		public Dictionary<int, decimal> EmissionsTotal { get; set; }

		public IEnumerable<GroupeSommaire> Groupes { get; set; }
	}
}
