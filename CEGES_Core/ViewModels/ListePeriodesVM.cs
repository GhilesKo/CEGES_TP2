using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CEGES_Core.ViewModels
{
	public class ListePeriodesVM
	{
		public Dictionary<int, List<Periode>> Periodes { get; set; }
		public Entreprise Entreprise { get; set; }
	}
}
