using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;
using WcfIntegrationXamarinForms.Service.WebService;
using WcfIntegrationXamarinForms.Service.WebService.Impl;
using WcfIntegrationXamarinForms.WcfServiceReference;

namespace WcfIntegrationXamarinForms.ViewModel
{
    /// <summary>
    /// This class contains static references to all the view models in the
    /// application and provides an entry point for the bindings.
    /// </summary>
    public class Locator
    {
        /// <summary>
        /// Initializes a new instance of the Locator class.
        /// </summary>
        public Locator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            SimpleIoc.Default.Register<IWcfService>(() => new WcfServiceClient(WcfServiceClient.EndpointConfiguration.BasicHttpsBinding_IWcfService));
            SimpleIoc.Default.Register<IWcfServiceWrapper, WcfServiceWrapper>();

            SimpleIoc.Default.Register<MainViewModel>();
        }

        public MainViewModel Main
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MainViewModel>();
            }
        }
        
        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }
}