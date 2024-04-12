using System.Configuration;
using System.Data;
using System.Windows;
using SellWoodTracker_ver2_0.Views;

namespace SellWoodTracker_ver2_0.Views
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var loginView = new LoginView();
            loginView.Show();
            loginView.IsVisibleChanged += (s, ev) =>
            {
                if (loginView.IsVisible == false && loginView.IsLoaded)
                {
                    var window1 = new Window1();
                    window1.Show();
                    loginView.Close();
                }
            };
        }       
    }
}
