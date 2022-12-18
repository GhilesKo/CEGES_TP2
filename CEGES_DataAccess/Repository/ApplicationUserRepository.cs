using CEGES_Core;
using CEGES_Core.IRepository;
using CEGES_DataAccess.Data;
using System.Collections.Generic;
using System.Linq;

namespace CEGES_DataAccess.Repository
{
  public class ApplicationUserRepository : RepositoryAsync<ApplicationUser>, IApplicationUserRepository
  {
    private readonly CegesDbContext _db;
    public ApplicationUserRepository(CegesDbContext db) : base(db)
    {
      _db = db;
    }
  }
}
