using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CEGES_Core.ViewModels
{
    public class EntrepriseSommaireVM
    {
        //public int Id { get; init; }
        public string Nom { get; init; }
        public decimal Total { get; init; }
        public IEnumerable<GroupeSommaireVM> Groupes { get; init; }
    }
}
