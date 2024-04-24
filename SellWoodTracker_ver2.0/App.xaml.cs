using System.Configuration;
using System.Data;
using System.Windows;
using System.Windows.Threading;
using Microsoft.Identity.Client;
using SellWoodTracker_ver2_0.Locators;
using SellWoodTracker_ver2_0.Views.Login;
using SellWoodTracker_ver2_0.Views.Main;

namespace SellWoodTracker_ver2_0.Views
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static string ConnectionString { get; private set; }

        public App()
        {
            
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            ConnectionString = ConfigurationManager.ConnectionStrings["LocalSqlConnection"].ConnectionString;
            RequestedBuyerServicesLocator.Initialize(ConnectionString);
            CompletedBuyerServicesLocator.Initialize(ConnectionString);

            base.OnStartup(e);

            Dispatcher.BeginInvoke(new Action(() =>
            {
                var loginView = new LoginView();
                loginView.Show();
                loginView.IsVisibleChanged += (s, ev) =>
                {
                    if (loginView.IsVisible == false && loginView.IsLoaded)
                    {
                        var mainView = new MainView();
                        mainView.Show();
                        loginView.Close();
                    }
                };
            }));
        }       
    }
}
