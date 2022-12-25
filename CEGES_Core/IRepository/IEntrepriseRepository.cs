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

        public Task<EntrepriseSommaireVM> GetEntrepriseStatistiquesSommaire(int entrepriseId, int periodeId);


		public Task<EntrepriseDetailsVM> GetEntrepriseStatistiquesDetails(int entrepriseId, int periodeId);



	}
}
