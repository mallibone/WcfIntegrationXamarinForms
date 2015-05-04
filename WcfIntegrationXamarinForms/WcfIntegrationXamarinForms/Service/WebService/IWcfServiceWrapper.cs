using System.Threading.Tasks;

namespace WcfIntegrationXamarinForms.Service.WebService
{
    public interface IWcfServiceWrapper
    {
        Task<string> GetDataAsync(int number);
    }
}