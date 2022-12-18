using CEGES_Core.IRepository;
using CEGES_DataAccess.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace CEGES_DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CegesDbContext _db;

        public IEntrepriseRepository Entreprises { get; private set; }
        public IGroupeRepository Groupes { get; private set; }
        public IEquipementRepository Equipements { get; private set; }
        public IMesureRepository Mesures { get; private set; }
        public IPeriodeRepository Periodes { get; private set; }
        public IApplicationUserRepository Users { get; private set; }

        public UnitOfWork(CegesDbContext db)
        {
            _db = db;

            Entreprises = new EntrepriseRepository(_db);
            Groupes = new GroupeRepository(_db);
            Equipements = new EquipementRepository(_db);
            Mesures = new MesureRepository(_db);
            Periodes = new PeriodeRepository(_db);
            Users = new ApplicationUserRepository(_db);
        }

        public void Dispose()
        {
            _db.Dispose();
        }

        public void Save()
        {
            _db.SaveChanges();
        }

    }
}
