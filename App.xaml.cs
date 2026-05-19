using System.Configuration;
using System.Data;
using System.Windows;
using Urbano_WPF.Data;
using Urbano_WPF.Helper;

namespace Urbano_WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            StartupUri = new Uri("Views/Login/LoginWindow.xaml", UriKind.Relative);
        }
    }

}
