using CEGES_Core.ViewModels;
using System.Collections.Generic;

namespace CEGES_Core.IRepository
{

    public interface IEntrepriseRepository : IRepositoryAsync<Entreprise>
    {
        void Update(Entreprise entreprise);
        public IEnumerable<ListeEntreprisesVM> GetEntreprisesAndCounts();
        public IEnumerable<ListeEntreprisesVM> GetAnalysteEntreprisesAndCountsAsync(string userId);


    }
}
