using System.Windows.Forms;
using RxUISimpleTimer.Core.Models;

namespace RxUISimpleTimer.WinForms.NativeModels
{
    public class DialogService : IDialogService
    {
        public void Notify(string msg, string title)
        {
            ShowMessageBox(msg, title, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public bool Confirm(string msg, string title)
        {
            var ret = ShowMessageBox(msg, title, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            return ret == DialogResult.Yes;
        }

        public void Warn(string msg, string title)
        {
            ShowMessageBox(msg, title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private DialogResult ShowMessageBox(string msg, string title, MessageBoxButtons buttons, MessageBoxIcon icon)
        {
            return MessageBox.Show(msg, title, buttons, icon);
        }
    }
}
