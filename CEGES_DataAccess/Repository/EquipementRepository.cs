using CEGES_Core;
using CEGES_Core.IRepository;
using CEGES_DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace CEGES_DataAccess.Repository
{
    public class EquipementRepository : RepositoryAsync<Equipement>, IEquipementRepository
    {
        private readonly CegesDbContext _db;

        public EquipementRepository(CegesDbContext db) : base(db)
        {
            _db = db;
        }

        public IEnumerable<Equipement> GetEquipements(int entrepriseId)
        {
            return _db.Equipements
                .Where(e => e.Groupe.EntrepriseId == entrepriseId)
                .Include(e => e.Groupe);
        }

        public void Update(Equipement equipement)
        {            
            _db.Update(equipement);
        }
    }
}
