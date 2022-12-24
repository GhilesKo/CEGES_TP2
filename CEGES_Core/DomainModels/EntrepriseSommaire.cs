using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CEGES_Core.DTOs
{
	public class EntrepriseSommaire
	{
		public int Id { get; init; }
		public string Nom { get; init; }
		public decimal EmissionTotal { get; init; }
		public IEnumerable<GroupeSommaire> Groupes { get; init; }
	}
}
