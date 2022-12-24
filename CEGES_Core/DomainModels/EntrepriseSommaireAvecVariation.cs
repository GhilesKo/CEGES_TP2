using CEGES_Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CEGES_Core.DomainModels
{
	public class EntrepriseSommaireAvecVariation
	{
		public string Nom { get; set; }

		public IEnumerable<EmissionTotal> EmissionsTotal { get; set; }

		public IEnumerable<GroupeSommaire> Groupes { get; set; }
	}
}
