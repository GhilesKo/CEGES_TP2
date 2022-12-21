using CEGES_Core.DTOs;
using CEGES_Core.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CEGES_Core.IRepository
{

    public interface IEntrepriseRepository : IRepositoryAsync<Entreprise>
    {
        void Update(Entreprise entreprise);
        public IEnumerable<ListeEntreprisesVM> GetEntreprisesAndCounts();
        public IEnumerable<ListeEntreprisesVM> GetAnalysteEntreprisesAndCountsAsync(string userId);

        public Task<EntrepriseSommaire> GetEntrepriseStatistiquesSommaire(int entrepriseId);

	}
}
