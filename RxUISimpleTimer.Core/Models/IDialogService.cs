namespace RxUISimpleTimer.Core.Models
{
    public interface IDialogService
    {
        void Notify(string msg, string title);

        bool Confirm(string msg, string title);

        void Warn(string msg, string title);
    }
}

