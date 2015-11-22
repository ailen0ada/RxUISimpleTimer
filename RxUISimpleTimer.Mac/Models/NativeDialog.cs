using System;
using RxUISimpleTimer.Core.Models;

namespace RxUISimpleTimer.Mac.Models
{
    public class NativeDialog : IDialogService
    {
        public NativeDialog()
        {
        }

        #region IDialogService implementation

        void IDialogService.Notify(string msg, string title)
        {
            throw new NotImplementedException();
        }

        bool IDialogService.Confirm(string msg, string title)
        {
            throw new NotImplementedException();
        }

        void IDialogService.Warn(string msg, string title)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}

