using CEGES_Core.IRepository;
using CEGES_Services.IServices;

namespace CEGES_Services
{
    public class CegesServices : ICegesServices
    {
        IUnitOfWork _uow;

        public IConfigurationServices Configuration { get; private set; }
        public IAnalyseServices Analyse { get; private set; }

        public CegesServices(IUnitOfWork unitOfWork)
        {
            _uow = unitOfWork;

            Configuration = new ConfigurationServices(_uow);
            Analyse = new AnalyseServices(_uow);
        }
    }
}
