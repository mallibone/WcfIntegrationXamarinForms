using System;
using System.Threading.Tasks;
using WcfIntegrationXamarinForms.WcfServiceReference;

namespace WcfIntegrationXamarinForms.Service.WebService.Impl
{
    public class WcfServiceWrapper:IWcfServiceWrapper
    {
        private IWcfService _wcfService;

        public WcfServiceWrapper(IWcfService wcfService)
        {
            if (wcfService == null) throw new ArgumentNullException("wcfService");

            _wcfService = wcfService;
        }

        public async Task<string> GetDataAsync(int number)
        {
            Task<string> getDataTask = new TaskFactory().FromAsync<int,string>(_wcfService.BeginGetData, _wcfService.EndGetData, number, null, TaskCreationOptions.None);
            return await getDataTask;
        }
    }
}
