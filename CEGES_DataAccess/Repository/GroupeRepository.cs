using CEGES_DataAccess.Data;
using CEGES_Core;
using CEGES_Core.IRepository;
using System.Collections.Generic;
using System.Linq;
using CEGES_Core.ViewModels;

namespace CEGES_DataAccess.Repository
{
    public class GroupeRepository : RepositoryAsync<Groupe>, IGroupeRepository
    {
        private readonly CegesDbContext _db;

        public GroupeRepository(CegesDbContext db) : base(db)
        {
            _db = db;
        }

        public IEnumerable<ListeGroupesVM> GetGroupesAndCounts(int entrepriseId)
        {
            return _db.Groupes.Where(g => g.EntrepriseId == entrepriseId)
                .Select(g => new ListeGroupesVM
                   {
                       Id = g.Id,
                       Nom = g.Nom,
                       Equipements = g.Equipements.Count()
                   }
                ).OrderBy(g => g.Nom);
        }

        public void Update(Groupe groupe)
        {
            Groupe groupeFromDb = base.FirstOrDefaultAsync(u => u.Id == groupe.Id).Result;
            if (groupeFromDb != null)
            {
                groupeFromDb.Nom = groupe.Nom;
            }
        }
    }
}
