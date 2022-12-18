
using CEGES_Core.ViewModels;
using System.Collections.Generic;

namespace CEGES_Core.IRepository
{
    public interface IGroupeRepository : IRepositoryAsync<Groupe>
    {
        void Update(Groupe groupe);
        IEnumerable<ListeGroupesVM> GetGroupesAndCounts(int entrepriseId);
    }
}
