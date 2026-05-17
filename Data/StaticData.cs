using System;
using System.Collections.Generic;
using System.Text;
using Urbano_WPF.ViewModels;

namespace Urbano_WPF.Data
{
    public static class StaticData
    {
        private static MainWindow mainWindow;

        public static MainWindow MainWindow { get { return mainWindow; } set { mainWindow = value; } }
    }
}
