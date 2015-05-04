using WcfIntegrationXamarinForms.View;
using WcfIntegrationXamarinForms.ViewModel;
using Xamarin.Forms;

namespace WcfIntegrationXamarinForms
{
    public class App : Application
    {
        private static Locator _locator;

        public static Locator Locator
        {
            get { return _locator ?? (_locator = new Locator()); }
        }

        public App()
        {
            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
