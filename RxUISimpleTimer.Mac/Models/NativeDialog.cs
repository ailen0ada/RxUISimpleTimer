using System;
using RxUISimpleTimer.Core.Models;
using AppKit;

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
            ShowAlert(msg, title, NSAlertStyle.Informational, false);
        }

        bool IDialogService.Confirm(string msg, string title)
        {
            var ret = ShowAlert(msg, title, NSAlertStyle.Informational, true);
            return ret == NSAlertButtonReturn.First;
        }

        void IDialogService.Warn(string msg, string title)
        {
            ShowAlert(msg, title, NSAlertStyle.Critical, false);
        }

        #endregion

        NSAlertButtonReturn ShowAlert(string msg, string title, NSAlertStyle alertStyle, bool showYesNo)
        {
            using (var alert = new NSAlert())
            {
                alert.MessageText = title;
                alert.InformativeText = msg;
                alert.AlertStyle = alertStyle;
                if (showYesNo)
                {
                    alert.AddButton("Yes");
                    alert.AddButton("No");
                }
                return (NSAlertButtonReturn)((int)alert.RunSheetModal(NSApplication.SharedApplication.KeyWindow));
            }
        }
    }
}

