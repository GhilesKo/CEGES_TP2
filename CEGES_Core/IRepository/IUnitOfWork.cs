using System;

namespace CEGES_Core.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        IEntrepriseRepository Entreprises { get; }
        IGroupeRepository Groupes { get; }
        IEquipementRepository Equipements { get; }
        IMesureRepository Mesures { get; }
        IPeriodeRepository Periodes { get; }

        IApplicationUserRepository Users { get; }
        void Save();
    }
}