using CEGES_Core;
using CEGES_Core.DomainModels;
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

		public async Task<EntrepriseSommaire> GetEntrepriseStatistiquesSommaire(int entrepriseId, int periodeId)
		{
			return await _db.Entreprises
				.AsNoTracking()
				.Where(e => e.Id == entrepriseId)
				.Select(e => new EntrepriseSommaire
				{

					Nom = e.Nom,
					Total = e.Groupes.SelectMany(g => g.Equipements).SelectMany(e => e.Mesures).Where(m => m.PeriodeId == periodeId).Select(m => m.Valeur).Sum(),
					Groupes = e.Groupes.Take(10).Select(g => new GroupeSommaire
					{
						//Id = g.Id,
						Nom = g.Nom,
						Total = g.Equipements.SelectMany(e => e.Mesures).Where(m => m.PeriodeId == periodeId).Select(m => m.Valeur).Sum()
					})
				})
				.FirstOrDefaultAsync();

		}
		public async Task<EntrepriseSommaireAvecVariation> GetEntrepriseStatistiquesSommaireAvecVariations(int entrepriseId, int periodeId, int periodeId2)
		{
			var test = await _db.Entreprises
				.AsNoTracking()
				.Where(e => e.Id == entrepriseId)
				.Select(e => new EntrepriseSommaireAvecVariation
				{
					Nom = e.Nom,
					EmissionsTotal = e.Groupes.SelectMany(g => g.Equipements).SelectMany(e => e.Mesures)
					.Where(m => m.PeriodeId == periodeId || m.PeriodeId == periodeId2)
					.GroupBy(m => m.PeriodeId)
					.Select(gr => new EmissionTotal
					{
						PeriodeId = gr.Key,
						Total = gr.Sum(x => x.Valeur)
					}),
					Groupes = e.Groupes.Take(10).Select(g => new GroupeSommaire
					{
						//Id = g.Id,
						Nom = g.Nom,
						Total = g.Equipements.SelectMany(e => e.Mesures).Where(m => m.PeriodeId == periodeId).Select(m => m.Valeur).Sum()
					})
				})
				.FirstOrDefaultAsync();
			return test;
			//return new EntrepriseSommaireAvecVariation();
		}

		public async Task<EntrepriseDetailsVM> GetEntrepriseStatistiquesDetails(int entrepriseId, int periodeId)
		{
			return await _db.Entreprises
				.AsNoTracking()
				//.Include(e => e.Groupes)
				//.ThenInclude(g => g.Equipements)
				//.ThenInclude(e => e.Mesures)
				.Where(e => e.Id == entrepriseId)
				.Select(e => new EntrepriseDetailsVM
				{
					Nom = e.Nom,
					Total = e.Groupes.SelectMany(g => g.Equipements).SelectMany(e => e.Mesures).Where(m => m.PeriodeId == periodeId).Select(m => m.Valeur).Sum(),
					Equipements = e.Groupes
						.SelectMany(g => g.Equipements)
						.SelectMany(e => e.Mesures)
						.Where(m => m.PeriodeId == periodeId)
						.Select(m => new EquipementDetails
						{
							Nom = m.Equipement.Nom,
							Groupe = m.Equipement.Groupe.Nom,
							Type = m.Equipement.Type.GetDisplayName(),
							Emission = m.Valeur,
						})


				})
				.FirstOrDefaultAsync();

		}

		public async Task<EntrepriseDetailsAvecVariation> GetEntrepriseStatistiquesDetailsAvecVariations(int entrepriseId, int periodeId, int periodeId2)
		{
			var test = await _db.Entreprises
				.AsNoTracking()
				.Where(e => e.Id == entrepriseId)
				.Select(e => new EntrepriseDetailsAvecVariation
				{
					Nom = e.Nom,
					EmissionsTotal = e.Groupes.SelectMany(g => g.Equipements).SelectMany(e => e.Mesures)
					.Where(m => m.PeriodeId == periodeId || m.PeriodeId == periodeId2)
					.GroupBy(m => m.PeriodeId)
					.Select(gr => new EmissionTotal
					{
						PeriodeId = gr.Key,
						Total = gr.Sum(x => x.Valeur)
					}),

					//EmissionTotalAnterieur = e.Groupes.SelectMany(g => g.Equipements).SelectMany(e => e.Mesures).Where(m => m.PeriodeId == periodeId2).Select(m => m.Valeur).Sum(),

					Equipements = e.Groupes
						.SelectMany(g => g.Equipements)
						.SelectMany(e => e.Mesures)
						.Where(m => m.PeriodeId == periodeId || m.PeriodeId == periodeId2)
						//.GroupBy(m => m.PeriodeId)
						.Select(m => new EquipementDetails
						{
							//PeriodeId = m.PeriodeId,
							Nom = m.Equipement.Nom,
							Groupe = m.Equipement.Groupe.Nom,
							Type = m.Equipement.Type.GetDisplayName(),
							Emission = m.Valeur,
						})

				})
				.FirstOrDefaultAsync();



			return test;



		}


	}
}
