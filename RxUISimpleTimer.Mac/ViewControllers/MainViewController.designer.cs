// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace RxUISimpleTimer.Mac.ViewControllers
{
	[Register ("MainViewController")]
	partial class MainViewController
	{
		[Outlet]
		AppKit.NSSplitViewItem HistoryViewItem { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (HistoryViewItem != null) {
				HistoryViewItem.Dispose ();
				HistoryViewItem = null;
			}
		}
	}
}
