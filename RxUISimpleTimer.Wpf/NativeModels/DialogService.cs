using System.Windows;
using RxUISimpleTimer.Core.Models;

namespace RxUISimpleTimer.Wpf.NativeModels
{
    public class DialogService : IDialogService
    {
        public void Notify(string msg, string title)
        {
            ShowMessageBox(msg, title, MessageBoxImage.Information, MessageBoxButton.OK);
        }

        public bool Confirm(string msg, string title)
        {
            var ret = ShowMessageBox(msg, title, MessageBoxImage.Exclamation, MessageBoxButton.YesNo);
            return ret == MessageBoxResult.Yes;
        }

        public void Warn(string msg, string title)
        {
            ShowMessageBox(msg, title, MessageBoxImage.Exclamation, MessageBoxButton.OK);
        }

        private MessageBoxResult ShowMessageBox(string msg, string title, MessageBoxImage image, MessageBoxButton button)
        {
            return MessageBox.Show(msg, title, button, image);
        }
    }
}
