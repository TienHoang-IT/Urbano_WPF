using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace Urbano_WPF.ViewModels.WindowControl
{
    public partial class WindowControlViewModel : ObservableObject
    {
        [ObservableProperty]
        private string maximizeIcon = "☐";

        [RelayCommand]
        private void Minimize(Window window)
        {
            if (window != null) window.WindowState = WindowState.Minimized;
        }

        [RelayCommand]
        private void Maximize(Window window)
        {
            if (window == null) return;

            if (window.WindowState == WindowState.Maximized)
            {
                window.WindowState = WindowState.Normal;
                MaximizeIcon = "☐";
            }
            else
            {
                window.WindowState = WindowState.Maximized;
                MaximizeIcon = "❐";
            }
        }

        [RelayCommand]
        private void Close(Window window)
        {
            window?.Close();
        }
    }
}
