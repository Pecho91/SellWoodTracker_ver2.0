using System.Configuration;
using System.Data;
using System.Windows;
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
        protected override void OnStartup(StartupEventArgs e)
        {
             
            //base.OnStartup(e);

            //var loginView = new LoginView();
            //loginView.Show();
            //loginView.IsVisibleChanged += (s, ev) =>
            //{
            //    if (loginView.IsVisible == false && loginView.IsLoaded)
            //    {
                    var mainView = new MainView();
                    mainView.Show();
            //        loginView.Close();
            //    }
            //};
        }       
    }
}
