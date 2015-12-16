using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using RxUISimpleTimer.Core.Models;
using RxUISimpleTimer.Wpf.NativeModels;
using Splat;

namespace RxUISimpleTimer.Wpf
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void App_OnStartup(object sender, StartupEventArgs e)
        {
            Locator.CurrentMutable.Register(() => new DialogService(), typeof(IDialogService));
        }
    }
}
