using CEGES_Core;
using CEGES_Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CEGES_Services.IServices
{
    public interface IAnalyseServices
	{
		public  Task<ListePeriodesVM> GetListePeriodesOriginal(int id);
		public Task<List<DetailMesureVM>> GetMesuresAsync(int entrepriseId, int periodeId);
		public Task<Dictionary<int, List<Periode>>> GetPeriodesEtAnnees(int id);
		public Task<IEnumerable<PeriodeVM>> GetListePeriodes(int id);


		public Task<int> PeriodeJoursAsync(int periodeId);
		public Task<ListeMesuresVM> GetPeriodeDetails(int entrepriseId, int periodeId);
		public Task<ListeMesuresVM> NewPeriodeAsync(int entrepriseId, DateTime periodeDebut);
		public Task<Periode> UpsertPeriodeAsync(ListeMesuresVM vm);
		public Task<IEnumerable<ApplicationUser>> GetAnalystesListAsync();

		public Task<EntrepriseSommaireVM> GetEntrepriseStatistiquesSommaire(int entrepriseId, int periodeId);
		public Task<EntrepriseSommaireAvecVariationVM> GetEntrepriseStatistiquesSommaireAvecVariations(int entrepriseId, int periodeId, string dateOption);

		public Task<EntrepriseDetailsVM> GetEntrepriseStatistiquesDetails(int entrepriseId, int periodeId);
		public Task<EntrepriseDetailsAvecVariationVM> GetEntrepriseStatistiquesDetailsAvecVariations(int entrepriseId, int periodeId, string dateOption);


	}
}