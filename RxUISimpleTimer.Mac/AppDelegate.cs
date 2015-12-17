using AppKit;
using Foundation;
using Splat;
using RxUISimpleTimer.Mac.Models;
using RxUISimpleTimer.Core.Models;
using RxUISimpleTimer.Core.ViewModels;
using System.Reactive.Concurrency;
using ReactiveUI;
using RxUISimpleTimer.Mac.Converters;

namespace RxUISimpleTimer.Mac
{
    [Register("AppDelegate")]
    public class AppDelegate : NSApplicationDelegate
    {
        public AppDelegate()
        {
            Locator.CurrentMutable.RegisterLazySingleton(() => new NativeDialog(), typeof(IDialogService));
            Locator.CurrentMutable.RegisterConstant(new CellStateConverter(), typeof(IBindingTypeConverter));
            Locator.CurrentMutable.RegisterLazySingleton(() => new OperationViewModel(RxApp.MainThreadScheduler), typeof(OperationViewModel));
        }

        public override void DidFinishLaunching(NSNotification notification)
        {
        }

        public override void WillTerminate(NSNotification notification)
        {
            // Insert code here to tear down your application
        }

        public override bool ApplicationShouldHandleReopen(NSApplication sender, bool hasVisibleWindows)
        {
            if (!hasVisibleWindows)
            {
                foreach (var window in sender.Windows)
                    window.MakeKeyAndOrderFront(this);
            }
            return true;
        }
    }
}

