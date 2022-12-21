using CEGES_Core;
using CEGES_Core.IRepository;
using CEGES_DataAccess.Data;
using CEGES_Services.IServices;
using Microsoft.AspNetCore.Identity;

namespace CEGES_Services
{
    public class CegesServices : ICegesServices
    {
        IUnitOfWork _uow;

        public IConfigurationServices Configuration { get; private set; }
        public IAnalyseServices Analyse { get; private set; }


        public CegesServices(IUnitOfWork unitOfWork, UserManager<ApplicationUser> userManager,CegesDbContext cegesDbContext)
        {
            _uow = unitOfWork;
            //_userManager = userManager;

            Configuration = new ConfigurationServices(_uow);
            Analyse = new AnalyseServices(_uow,userManager, cegesDbContext);
        }
    }
}
