using System.Configuration;
using System.Data;
using System.Windows;
using Urbano_WPF.Data;

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

            InitViewModel();
        }

        private void InitViewModel()
        {
            StaticData.MainViewModel = new ViewModels.MainViewModel();
        }
    }

}
