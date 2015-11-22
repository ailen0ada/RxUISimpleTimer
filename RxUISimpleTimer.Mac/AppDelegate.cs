using AppKit;
using Foundation;
using Splat;
using RxUISimpleTimer.Mac.Models;
using RxUISimpleTimer.Core.Models;

namespace RxUISimpleTimer.Mac
{
    [Register("AppDelegate")]
    public class AppDelegate : NSApplicationDelegate
    {
        public AppDelegate()
        {
        }

        public override void DidFinishLaunching(NSNotification notification)
        {
            Locator.CurrentMutable.RegisterLazySingleton(() => NativeDialog, typeof(IDialogService));
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

