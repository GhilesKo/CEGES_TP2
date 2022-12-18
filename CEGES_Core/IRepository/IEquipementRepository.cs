
using System.Collections.Generic;

namespace CEGES_Core.IRepository
{
    public interface IEquipementRepository : IRepositoryAsync<Equipement>
    {
        void Update(Equipement equipement);
        public IEnumerable<Equipement> GetEquipements(int entrepriseId);
    }
}
