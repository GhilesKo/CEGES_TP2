using CEGES_Core;
using CEGES_Core.IRepository;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using CEGES_Services.IServices;
using System;
using CEGES_Core.Factories;
using CEGES_Core.ViewModels;
using CEGES_Core.Exceptions;

namespace CEGES_Services
{
    public class ConfigurationServices : IConfigurationServices
    {
        IUnitOfWork _uow;
        public ConfigurationServices(IUnitOfWork unitOfWork)
        {
            _uow = unitOfWork;
        }

        public async Task EditAnalystesEntrepriseAsync(int entrepriseId, List<string> analysteIds)
        {
            Entreprise entreprise = await _uow.Entreprises.FirstOrDefaultAsync(e => e.Id == entrepriseId, "Analystes");

            if (entreprise == null)
                throw new KeyNotFoundException();

            IEnumerable<ApplicationUser> analystes = await _uow.Users.GetAllAsync(u => analysteIds.Contains(u.Id), "Entreprises");

            if (analystes.Count() != analysteIds.Count)
            {
                throw new KeyNotFoundException();
            }

            entreprise.Analystes = analystes.ToList();

            foreach (ApplicationUser analyste in entreprise.Analystes)
            {
                if (analyste.Entreprises.Count > 3 || (analyste.Entreprises.Count == 3 && !analyste.Entreprises.Exists(e => e.Id == entrepriseId)))
                    throw new TooManyAnalystesEntreprisesException(analyste.UserName);
            }
            _uow.Save();
        }

        public async Task AddEntrepriseAsync(Entreprise entreprise)
        {
            await _uow.Entreprises.AddAsync(entreprise);
            _uow.Save();
        }

        public async Task AddEquipementAsync(Equipement equipement)
        {
            await _uow.Equipements.AddAsync(equipement);
            _uow.Save();
        }

        public async Task AddGroupeAsync(Groupe groupe)
        {
            await _uow.Groupes.AddAsync(groupe);
            _uow.Save();
        }

        public async Task<Entreprise> GetEntrepriseAsync(int id)
        {
            IEnumerable<Entreprise> entreprises = await _uow.Entreprises.GetAllAsync(e => e.Id == id, "Analystes");
            return entreprises.FirstOrDefault();
        }

        public async Task<DetailEntrepriseVM> GetEntrepriseDetailAsync(int id)
        {
            DetailEntrepriseVM vm = new DetailEntrepriseVM()
            {
                Entreprise = await _uow.Entreprises.GetAsync(id),
                Groupes = GetGroupesAndCounts(id)
            };
            return vm;
        }

        public List<ListeEntreprisesVM> GetEntreprisesAndCountsAsync()
        {
            return _uow.Entreprises.GetEntreprisesAndCounts().ToList();
        }

        public List<ListeEntreprisesVM> GetAnalysteEntreprisesAndCountsAsync(string userId)
        {
            return _uow.Entreprises.GetAnalysteEntreprisesAndCountsAsync(userId).ToList();
        }

        public async Task<Equipement> GetEquipementDetailAsync(int id)
        {
            IEnumerable<Equipement> equipements = await _uow.Equipements.GetAllAsync(e => e.Id == id, null, "Groupe");
            return equipements.FirstOrDefault();
        }

        public async Task<Groupe> GetGroupeAsync(int id)
        {
            return await _uow.Groupes.GetAsync(id);
        }

        public async Task<Groupe> GetGroupeDetailsAsync(int id)
        {
            IEnumerable<Groupe> groupes = await _uow.Groupes.GetAllAsync(g => g.Id == id, null, "Entreprise,Equipements");
            return groupes.FirstOrDefault();
        }

        public async Task<Groupe> GetGroupeEtEntrepriseAsync(int id)
        {
            IEnumerable<Groupe> groupes = await _uow.Groupes.GetAllAsync(g => g.Id == id, null, "Entreprise");
            return groupes.FirstOrDefault();
        }

        public async Task<Equipement> NewEquipementAsync(int id, string type)
        {
            if (!Enum.TryParse(type, true, out EquipementType equipmentType))
            {
                return null;
            }
            Equipement equipement = EquipementFactory.CreateEquipement(equipmentType);
            equipement.Groupe = await _uow.Groupes.GetAsync(id);
            equipement.GroupeId = equipement.Groupe.Id;
            return equipement;
        }

        public async Task<Groupe> NewGroupeAsync(int entrepriseId)
        {
            Groupe groupe = new Groupe();
            groupe.Entreprise = await _uow.Entreprises.GetAsync(entrepriseId);
            if (groupe.Entreprise == null)
            {
                return null;
            }
            groupe.EntrepriseId = groupe.Entreprise.Id;
            return groupe;
        }

        public void UpdateEntreprise(Entreprise entreprise)
        {
            _uow.Entreprises.Update(entreprise);
            _uow.Save();
        }

        public void UpdateEquipement(Equipement equipement)
        {
            _uow.Equipements.Update(equipement);
            _uow.Save();
        }

        public void UpdateGroupe(Groupe groupe)
        {
            _uow.Groupes.Update(groupe);
            _uow.Save();
        }

        private List<ListeGroupesVM> GetGroupesAndCounts(int entrepriseId)
        {
            return _uow.Groupes.GetGroupesAndCounts(entrepriseId).Select(g => new ListeGroupesVM
                {
                    Id = g.Id,
                    Nom = g.Nom,
                    Equipements = g.Equipements
                })
                .ToList();
        }
    }
}
