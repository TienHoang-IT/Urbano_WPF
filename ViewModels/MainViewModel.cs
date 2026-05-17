using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using HandyControl.Controls;
using System;
using System.Collections.Generic;
using System.Runtime.Intrinsics.X86;
using System.Text;
using Urbano_WPF.Data;
using Urbano_WPF.ViewModels.Employee;
using Urbano_WPF.Views.Employee;

namespace Urbano_WPF.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {
        public MainViewModel()
        {

        }

        //Relay
        [RelayCommand]
        private void Employee()
        {
            var win = new EmployeeWindow();
            win.Owner = StaticData.MainWindow;
            win.Show();
        }
        [RelayCommand]
        private void Category()
        {
            Growl.Info("Category Button");
        }
        [RelayCommand]
        private void System()
        {
            Growl.Info("System Button");
        }
        [RelayCommand]
        private void Diary()
        {
            Growl.Info("Diary Button");
        }
        [RelayCommand]
        private void Payment()
        {
            Growl.Info("Payment Button");
        }
    }
}
