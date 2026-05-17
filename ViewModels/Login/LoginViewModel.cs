using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using HandyControl.Controls;
using System;
using System.Collections.Generic;
using System.Text;
using Urbano_WPF.Data;
using Urbano_WPF.Helper;
using Urbano_WPF.Views.MessageBoxCustom;

namespace Urbano_WPF.ViewModels.Login
{
    public partial class LoginViewModel : ObservableObject
    {
        public Action CloseAction;

        //Fields
        [ObservableProperty]
        private string username;
        [ObservableProperty]
        private string password;


        public LoginViewModel(Action closeAction)
        {
            CloseAction = closeAction;
        }

        [RelayCommand]
        private void Login()
        {
            try
            {
                if(string.IsNullOrWhiteSpace(Username) || string.IsNullOrWhiteSpace(Password))
                {
                    MessageBoxCustom.Show("Vui lòng nhập đầy đủ thông tin đăng nhập!", Enums.MessageType.Warning, Enums.MessageDialogButtonType.Ok);
                    return;
                }

                var mainwindow = new MainWindow();
                StaticData.MainWindow = mainwindow;
                mainwindow.WindowState = System.Windows.WindowState.Maximized;
                mainwindow.Show();
                CloseAction?.Invoke();
            }
            catch(Exception ex)
            {
                MessageBoxCustom.Show("Sảy ra lỗi khi đăng nhập, vui lòng thử lại!",Enums.MessageType.Warning,Enums.MessageDialogButtonType.Ok);
                Logger.WriteLine("Lỗi đăng nhập: " + ex.Message);
                CloseAction?.Invoke();
            }
        }

        [RelayCommand]
        private void Cancel()
        {
            CloseAction?.Invoke();
        }
    }
}
