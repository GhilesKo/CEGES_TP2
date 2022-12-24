using System.Threading.Tasks;

namespace CEGES_Services.IServices
{
    public interface ICegesServices
    {
        public IConfigurationServices Configuration { get; }
        public IAnalyseServices Analyse { get; }

	}
}