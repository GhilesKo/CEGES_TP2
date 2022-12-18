using CEGES_DataAccess.Data;
using CEGES_Core;
using CEGES_Core.IRepository;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace CEGES_DataAccess.Repository
{
    public class PeriodeRepository : RepositoryAsync<Periode>, IPeriodeRepository
    {
        private readonly CegesDbContext _db;

        public PeriodeRepository(CegesDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Periode periode)
        {
            Periode periodeFromDb = FirstOrDefaultAsync(u => u.Id == periode.Id).Result;
            if (periodeFromDb != null)
            {
                periodeFromDb.Debut = periode.Debut;
                periodeFromDb.Fin = periode.Fin;
            }
        }
        public IEnumerable<Mesure> GetMesures(int entrepriseId, int periodeId)
        {
            return _db.Mesures.Where(m => m.PeriodeId == periodeId && m.Equipement.Groupe.EntrepriseId == entrepriseId)
                .Include(m => m.Equipement)
                .ThenInclude(e => e.Groupe);
        }
    }
}
