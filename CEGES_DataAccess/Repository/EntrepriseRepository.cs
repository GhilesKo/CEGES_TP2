using CEGES_Core;
using CEGES_Core.DTOs;
using CEGES_Core.IRepository;
using CEGES_Core.ViewModels;
using CEGES_DataAccess.Data;
using CEGES_Util;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CEGES_DataAccess.Repository
{
    public class EntrepriseRepository : RepositoryAsync<Entreprise>, IEntrepriseRepository
	{
		private readonly CegesDbContext _db;

		public EntrepriseRepository(CegesDbContext db) : base(db)
		{
			_db = db;
		}

		public void Update(Entreprise entreprise)
		{
			Entreprise entrepriseFromDb = base.FirstOrDefaultAsync(u => u.Id == entreprise.Id).Result;
			if (entrepriseFromDb != null)
			{
				entrepriseFromDb.Nom = entreprise.Nom;
			}
		}

		public IEnumerable<ListeEntreprisesVM> GetEntreprisesAndCounts()
		{
			return _db.Entreprises
				.Select(e => new ListeEntreprisesVM
				{
					Id = e.Id,
					Nom = e.Nom,
					Groupes = e.Groupes.Count,
					Equipements = e.Groupes.SelectMany(g => g.Equipements).Count(),
					Periodes = e.Groupes.SelectMany(g => g.Equipements).SelectMany(n => n.Mesures).Select(m => m.Periode.Debut).Distinct().Count()
				});
		}

		public IEnumerable<ListeEntreprisesVM> GetAnalysteEntreprisesAndCountsAsync(string userId)
		{
			var user = _db.Users
				.Where(u => u.Id == userId)
				.Select(e => new
				{
					EntreprisesVMs = e.Entreprises.Select(e => new ListeEntreprisesVM
					{
						Id = e.Id,
						Nom = e.Nom,
						Groupes = e.Groupes.Count,
						Equipements = e.Groupes.SelectMany(g => g.Equipements).Count(),
						Periodes = e.Groupes.SelectMany(g => g.Equipements).SelectMany(n => n.Mesures).Select(m => m.Periode.Debut).Distinct().Count()
					}).ToList()

				}).FirstOrDefault();

			return user.EntreprisesVMs;
		}

		public async Task<EntrepriseSommaireVM> GetEntrepriseStatistiquesSommaire(int entrepriseId, int periodeId)
		{
			return await _db.Entreprises
				// Pas besoin de track l'entité, nous effectuons pas de changements
				.AsNoTracking()
				.Where(e => e.Id == entrepriseId)
				.Select(e => new EntrepriseSommaireVM
				{

					Nom = e.Nom,
					Total = e.Groupes.SelectMany(g => g.Equipements).SelectMany(e => e.Mesures).Where(m => m.PeriodeId == periodeId).Select(m => m.Valeur).Sum(),
					Groupes = e.Groupes.Take(10).Select(g => new GroupeSommaireVM
					{
						//Id = g.Id,
						Nom = g.Nom,
						Total = g.Equipements.SelectMany(e => e.Mesures).Where(m => m.PeriodeId == periodeId).Select(m => m.Valeur).Sum()
					})
				})
				.FirstOrDefaultAsync();

		}

		public async Task<EntrepriseDetailsVM> GetEntrepriseStatistiquesDetails(int entrepriseId, int periodeId)
		{
			return await _db.Entreprises
				// Pas besoin de track l'entité, nous effectuons pas de changements
				.AsNoTracking()
				// Pas besoin d'inclued, nous somme dans la base de donne
				.Where(e => e.Id == entrepriseId)
				.Select(e => new EntrepriseDetailsVM
				{
					Nom = e.Nom,
					Total = e.Groupes.SelectMany(g => g.Equipements).SelectMany(e => e.Mesures).Where(m => m.PeriodeId == periodeId).Select(m => m.Valeur).Sum(),
					Equipements = e.Groupes
						.SelectMany(g => g.Equipements)
						.SelectMany(e => e.Mesures)
						.Where(m => m.PeriodeId == periodeId)
						.Select(m => new EquipementDetailsVM
						{
							Nom = m.Equipement.Nom,
							Groupe = m.Equipement.Groupe.Nom,
							Type = m.Equipement.Type.GetDisplayName(),
							Emission = m.Valeur,
							//Here i would like to use the total from up there to not have to re calculate everytime
							//This would cause performance issue..
							//e.Groupes.SelectMany(g => g.Equipements).SelectMany(e => e.Mesures).Where(m => m.PeriodeId == periodeId).Select(m => m.Valeur).Sum()
							//Pourcentage = Total //<--- this causes an error  "The name 'Total' does not exist in the current context"
						}).ToList()


				})
				.FirstOrDefaultAsync();

		}



	}
}
