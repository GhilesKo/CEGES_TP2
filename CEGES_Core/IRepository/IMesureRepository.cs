namespace CEGES_Core.IRepository
{
    public interface IMesureRepository : IRepositoryAsync<Mesure>
    {
        void Update(Mesure mesure);
    }
}
