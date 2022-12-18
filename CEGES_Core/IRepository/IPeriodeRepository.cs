using System.Collections.Generic;

namespace CEGES_Core.IRepository
{
    public interface IPeriodeRepository : IRepositoryAsync<Periode>
    {
        void Update(Periode periode);
        public IEnumerable<Mesure> GetMesures(int entrepriseId, int periodeId);
    }
}
