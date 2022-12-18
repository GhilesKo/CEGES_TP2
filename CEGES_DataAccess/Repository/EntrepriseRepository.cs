using CEGES_Core;
using CEGES_Core.IRepository;
using CEGES_Core.ViewModels;
using CEGES_DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

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
    }
}
