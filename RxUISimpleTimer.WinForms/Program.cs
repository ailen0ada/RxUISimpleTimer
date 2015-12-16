using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using RxUISimpleTimer.Core.Models;
using RxUISimpleTimer.Core.ViewModels;
using RxUISimpleTimer.WinForms.NativeModels;
using Splat;

namespace RxUISimpleTimer.WinForms
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Locator.CurrentMutable.Register(() => new DialogService(), typeof(IDialogService));

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
