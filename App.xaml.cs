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

            InitViewModel();
        }

        private void InitViewModel()
        {
            try
            {
                StaticData.MainViewModel = new ViewModels.MainViewModel();
                Logger.WriteLine("Khởi tạo toàn bộ ViewModel");
            }
            catch(Exception ex)
            {
                Logger.WriteLine("Lỗi khởi tạo ViewModel: " + ex.Message);
            }
        }
    }

}
