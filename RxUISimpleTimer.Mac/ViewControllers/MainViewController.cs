using System;
using AppKit;
using Foundation;
using ReactiveUI;

namespace RxUISimpleTimer.Mac.ViewControllers
{
    public partial class MainViewController : NSSplitViewController
    {
        public MainViewController(IntPtr handle)
            : base(handle)
        {
        }

        public NSSplitViewItem HistoryView{ get { return HistoryViewItem; } }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            // Do any additional setup after loading the view.

            View.WantsLayer = true;
        }

        public override NSObject RepresentedObject
        {
            get
            {
                return base.RepresentedObject;
            }
            set
            {
                base.RepresentedObject = value;
                // Update the view, if already loaded.
            }
        }
    }
}
