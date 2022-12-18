using CEGES_Core;
using CEGES_Core.IRepository;
using CEGES_DataAccess.Data;

namespace CEGES_DataAccess.Repository
{
    public class MesureRepository : RepositoryAsync<Mesure>, IMesureRepository
    {
        private readonly CegesDbContext _db;

        public MesureRepository(CegesDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Mesure mesure)
        {
            Mesure mesureFromDb = base.FirstOrDefaultAsync(u => u.Id == mesure.Id).Result;
            if (mesureFromDb != null)
            {
                mesureFromDb.Valeur = mesure.Valeur;
            }
        }
    }
}
