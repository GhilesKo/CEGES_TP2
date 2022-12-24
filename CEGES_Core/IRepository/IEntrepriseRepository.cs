using CEGES_Core.DomainModels;
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

        public Task<EntrepriseSommaire> GetEntrepriseStatistiquesSommaire(int entrepriseId, int periodeId);

		public Task<EntrepriseSommaireAvecVariation> GetEntrepriseStatistiquesSommaireAvecVariations(int entrepriseId, int periodeId, int periodeId2);

		public Task<EntrepriseDetails> GetEntrepriseStatistiquesDetails(int entrepriseId, int periodeId);

		public Task<EntrepriseDetailsAvecVariation> GetEntrepriseStatistiquesDetailsAvecVariations(int entrepriseId, int periodeId,int periodeId2);


	}
}
