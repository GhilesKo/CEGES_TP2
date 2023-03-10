using CEGES_Core;
using CEGES_Core.DTOs;
using CEGES_Core.IRepository;
using CEGES_Core.ViewModels;
using CEGES_DataAccess.Data;
using CEGES_Services.IServices;
using CEGES_Util;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CEGES_Services
{
    public class AnalyseServices : IAnalyseServices
	{
		IUnitOfWork _uow;

		private readonly UserManager<ApplicationUser> _userManager;
		private readonly CegesDbContext _cegesDbContext;

		public AnalyseServices(IUnitOfWork unitOfWork, UserManager<ApplicationUser> userManager, CegesDbContext cegesDbContext)
		{
			_uow = unitOfWork;
			_cegesDbContext = cegesDbContext;
			_userManager = userManager;
		}




		private Dictionary<int, List<Periode>> AddPeriodesManquantes(Dictionary<int, List<Periode>> periodesExistantes)
		{
			int annee = DateTime.Now.Year;
			int mois = DateTime.Now.Month;
			for (int i = annee - 1; i <= annee; i++)
			{
				if (!periodesExistantes.ContainsKey(i))
				{
					periodesExistantes.Add(i, new List<Periode>());
				}
				for (int j = 1; j <= 12; j++)
				{
					DateTime debutMois = new DateTime(i, j, 1);
					if (!periodesExistantes[i].Exists(p => p.Debut == debutMois))
					{
						periodesExistantes[i].Add(new Periode(debutMois));
					}
					if (annee == i && mois == j)
						break;
				}
			}
			return periodesExistantes;
		}

		public async Task<List<DetailMesureVM>> GetMesuresAsync(int entrepriseId, int periodeId)
		{
			List<DetailMesureVM> liste = new List<DetailMesureVM>();
			Periode periode = await _uow.Periodes.GetAsync(periodeId);
			int jours = DateTime.DaysInMonth(periode.Debut.Year, periode.Debut.Month);

			return _uow.Periodes.GetMesures(entrepriseId, periodeId)
				.Select(m => new DetailMesureVM()
				{
					Id = m.Id,
					Groupe = m.Equipement.Groupe.Nom,
					Equipement = m.Equipement.Nom,
					EquipementId = m.Equipement.Id,
					Type = m.Equipement.Type.ToString(),
					Mesure = m.Valeur,
					UniteMesure = m.Equipement.GetUniteMesure(),
					Formule = m.Equipement.Formule(jours, m.Valeur),
					Emissions = m.Equipement.EmissionsMensuelles(jours, m.Valeur)
				}).ToList();
		}


		public async Task<Dictionary<int, List<Periode>>> GetPeriodesEtAnnees(int id)
		{
			IEnumerable<Periode> periodes = await _uow.Periodes.GetAllAsync(p => p.EntrepriseId == id, q => q.OrderBy(p => p.Debut), isTracking: false, includeProperties: "Mesures.Equipement.Groupe,Entreprise");
			Dictionary<int, List<Periode>> py = new Dictionary<int, List<Periode>>();
			foreach (Periode p in periodes)
			{
				int year = p.Debut.Year;
				if (py.ContainsKey(year))
				{
					py[year].Add(p);
				}
				else
				{
					py.Add(year, new List<Periode> { p });
				}
			}
			return py;
		}

		public async Task<int> PeriodeJoursAsync(int periodeId)
		{
			Periode periode = await _uow.Periodes.GetAsync(periodeId);
			return DateTime.DaysInMonth(periode.Debut.Year, periode.Debut.Month);
		}

		public async Task<ListeMesuresVM> GetPeriodeDetails(int entrepriseId, int periodeId)
		{
			Entreprise e = await _uow.Entreprises.GetAsync(entrepriseId);
			Periode p = await _uow.Periodes.GetAsync(periodeId);
			ListeMesuresVM vm = new ListeMesuresVM()
			{
				EntrepriseId = e.Id,
				EntrepriseNom = e.Nom,
				PeriodeId = p.Id,
				PeriodeNom = p.Nom,
				PeriodeDebut = p.Debut,
				Mesures = await GetMesuresAsync(entrepriseId, periodeId)
			};
			return vm;
		}

		public async Task<ListeMesuresVM> NewPeriodeAsync(int entrepriseId, DateTime periodeDebut)
		{
			Entreprise e = await _uow.Entreprises.GetAsync(entrepriseId);
			Periode p = new Periode(periodeDebut);
			ListeMesuresVM vm = new ListeMesuresVM()
			{
				EntrepriseId = e.Id,
				EntrepriseNom = e.Nom,
				PeriodeId = p.Id,
				PeriodeNom = p.Nom,
				PeriodeDebut = p.Debut,
				Mesures = CreateMesures(entrepriseId, DateTime.DaysInMonth(periodeDebut.Year, periodeDebut.Month))
			};
			return vm;
		}
		private List<DetailMesureVM> CreateMesures(int entrepriseId, int jours)
		{
			return _uow.Equipements.GetEquipements(entrepriseId)
				.Select(e => new DetailMesureVM()
				{
					Id = 0,
					Groupe = e.Groupe.Nom,
					Equipement = e.Nom,
					EquipementId = e.Id,
					Type = e.Type.ToString(),
					Mesure = 0,
					UniteMesure = e.GetUniteMesure(),
					Formule = e.Formule(jours, 0),
					Emissions = e.EmissionsMensuelles(jours, 0)
				}).ToList();
		}

		public async Task<Periode> UpsertPeriodeAsync(ListeMesuresVM vm)
		{
			Periode periode;
			if (vm.PeriodeId == 0)
			{
				periode = new Periode(vm.PeriodeDebut) { EntrepriseId = vm.EntrepriseId };
				await _uow.Periodes.AddAsync(periode);
				_uow.Save();
			}
			else
			{
				periode = await _uow.Periodes.GetAsync(vm.PeriodeId);
			}
			foreach (DetailMesureVM mesureVM in vm.Mesures)
			{
				Mesure mesure;
				if (vm.PeriodeId == 0)
				{
					mesure = new Mesure()
					{
						EquipementId = mesureVM.EquipementId,
						PeriodeId = periode.Id,
						Valeur = mesureVM.Mesure
					};
					await _uow.Mesures.AddAsync(mesure);
				}
				else
				{
					mesure = await _uow.Mesures.GetAsync(mesureVM.Id);
					mesure.Valeur = mesureVM.Mesure;
					_uow.Mesures.Update(mesure);
				}
			}
			_uow.Save();
			return periode;
		}

		public async Task<IEnumerable<ApplicationUser>> GetAnalystesListAsync()
		{
			return await _userManager.GetUsersInRoleAsync(AppConstants.AnalysteRole);
			//return await _uow.Users.GetAllAsync();
		}


		public async Task<ListePeriodesVM> GetListePeriodesOriginal(int id)
		{
			ListePeriodesVM vm = new ListePeriodesVM()
			{
				Periodes = await GetPeriodesEtAnnees(id),
				Entreprise = await _uow.Entreprises.GetAsync(id)
			};
			vm.Periodes = AddPeriodesManquantes(vm.Periodes);
			return vm;
		}


		//a ete modifié
		public async Task<IEnumerable<PeriodeVM>> GetListePeriodes(int id)
		{

			var periodes = await GetPeriodesEtAnnees(id);

			//periodes = AddPeriodesManquantes(periodes);


			var vm = periodes.SelectMany(p => p.Value).Where(p => p.Mesures.Any());

			//var entreprise = vm.FirstOrDefault().Entreprise;

			var vm2 = vm.Select(p => new PeriodeVM
			{
				//Entreprise = entreprise.Nom,
				Id = p.Id,
				Nom = p.Nom,
				Debut = p.Debut,
				Fin = p.Fin,
			});



			return vm2;
		}

		//My methodes
		public async Task<EntrepriseSommaireVM> GetEntrepriseStatistiquesSommaire(int entrepriseId, int periodeId)
		{
			var entrepriseSommaireVM = await _uow.Entreprises.GetEntrepriseStatistiquesSommaire(entrepriseId, periodeId);

			if (entrepriseSommaireVM == null)
			{
				throw new Exception($"Statistics for period '{periodeId}' not found");
			}

			return entrepriseSommaireVM;
		}


		public async Task<EntrepriseDetailsVM> GetEntrepriseStatistiquesDetails(int entrepriseId, int periodeId)
		{
			var entrepriseDetailsVM = await _uow.Entreprises.GetEntrepriseStatistiquesDetails(entrepriseId, periodeId);

			if (entrepriseDetailsVM == null)
			{
				throw new Exception($"Statistics for period '{periodeId}' not found");
			}

			//rajoute un pourcentage pour chaque equipements, puisque nous pouvions pas le faire dans la methode du repository sans ruiner les performances, 
			//donc on effectur le calcul une fois loader en memory
			entrepriseDetailsVM.Equipements.All(x => { x.Pourcentage = x.Emission / entrepriseDetailsVM.Total; return true; });



			return entrepriseDetailsVM;
		}

		public async Task<EntrepriseDetailsAvecVariationVM> GetEntrepriseStatistiquesDetailsAvecVariations(int entrepriseId, int periodeId, string dateOption)
		{
			//check if periode exist;
			var periode = await _uow.Periodes.FirstOrDefaultAsync(p => p.Id == periodeId && p.EntrepriseId == entrepriseId, includeProperties: "Mesures.Equipement.Groupe,Entreprise", isTracking: false);

			if (periode == null)
			{
				throw new Exception($"Periode '{periodeId}' not found");
			}

			//same year
			var sameYear = periode.Debut.AddMonths(-1);

			//last year
			var lastYear = periode.Debut.AddYears(-1);

			//check if periode has an antecedant (same year / last year)
			//options:  same vs last
			var periodeAnterieur = dateOption == "same"
				? await _uow.Periodes.FirstOrDefaultAsync(filter: p => p.Debut.Date == sameYear.Date && p.Id != periodeId && p.EntrepriseId == entrepriseId, includeProperties: "Mesures", isTracking: false)
				: await _uow.Periodes.FirstOrDefaultAsync(filter: p => p.Debut.Date == lastYear.Date && p.Id != periodeId && p.EntrepriseId == entrepriseId, includeProperties: "Mesures", isTracking: false);


			if (periodeAnterieur == null)
			{
				throw new Exception($"Aucune periode anterieur à '{periodeId}'");
			}

			var Total = periode.Mesures.Sum(m => m.Valeur);
			var TotalPeriodeAnterieure = periodeAnterieur.Mesures.Sum(m => m.Valeur);

			var entrepriseDetailsVariationVM = new EntrepriseDetailsAvecVariationVM
			{
				Nom = periode.Entreprise.Nom,
				Total = Total,
				TotalPeriodeAnterieure = TotalPeriodeAnterieure,
				Equipements = periode.Mesures.Select(m => new EquipementDetailsVM
				{
					//Id = m.EquipementId,
					Nom = m.Equipement.Nom,
					Groupe = m.Equipement.Groupe.Nom,
					Type = m.Equipement.Type.GetDisplayName(),
					Emission = m.Valeur,
					Pourcentage = m.Valeur / Total,
					EmissionAnterieure = periodeAnterieur.Mesures.FirstOrDefault(c => c.EquipementId == m.EquipementId).Valeur
				})
			};


			return entrepriseDetailsVariationVM;

		}

		public async Task<EntrepriseSommaireAvecVariationVM> GetEntrepriseStatistiquesSommaireAvecVariations(int entrepriseId, int periodeId, string dateOption)
		{
			//check if periode exist;
			var periode = await _uow.Periodes.FirstOrDefaultAsync(p => p.Id == periodeId && p.EntrepriseId == entrepriseId, includeProperties: "Mesures.Equipement.Groupe,Entreprise", isTracking: false);

			if (periode == null)
			{
				throw new Exception($"Periode '{periodeId}' not found");
			}

			//same year
			var sameYear = periode.Debut.AddMonths(-1);

			//last year
			var lastYear = periode.Debut.AddYears(-1);

			//check if periode has an antecedant (same year / last year)
			//options:  same vs last
			var periodeAnterieur = dateOption == "same"
				? await _uow.Periodes.FirstOrDefaultAsync(filter: p => p.Debut.Date == sameYear.Date && p.Id != periodeId && p.EntrepriseId == entrepriseId, includeProperties: "Mesures", isTracking: false)
				: await _uow.Periodes.FirstOrDefaultAsync(filter: p => p.Debut.Date == lastYear.Date && p.Id != periodeId && p.EntrepriseId == entrepriseId, includeProperties: "Mesures", isTracking: false);

			if (periodeAnterieur == null)
			{
				throw new Exception($"Aucune periode anterieur à '{periodeId}'");
			}

			var entrepriseSommaireVariationVM = new EntrepriseSommaireAvecVariationVM
			{
				Nom = periode.Entreprise.Nom,
				Total = periode.Mesures.Sum(m => m.Valeur),
				TotalPeriodeAnterieure = periodeAnterieur.Mesures.Sum(m => m.Valeur),
				Groupes = periode.Mesures.GroupBy(m => m.Equipement.Groupe.Nom).Select(gr => new GroupeSommaireVM
				{
					Nom = gr.Key,
					Total = gr.Sum(m => m.Valeur)
				}).Take(10)
			};



			return entrepriseSommaireVariationVM;
		}

	}
}
