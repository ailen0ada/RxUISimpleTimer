// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace RxUISimpleTimer.Mac
{
	[Register ("MainWindowController")]
	partial class MainWindowController
	{
		[Outlet]
		AppKit.NSToolbarItem LapButtonItem { get; set; }

		[Outlet]
		AppKit.NSToolbarItem StartButtonItem { get; set; }

		[Outlet]
		AppKit.NSToolbarItem StopButtonItem { get; set; }

		[Action ("ShowHistoryBar:")]
		partial void ShowHistoryBar (Foundation.NSObject sender);
		
		void ReleaseDesignerOutlets ()
		{
			if (StartButtonItem != null) {
				StartButtonItem.Dispose ();
				StartButtonItem = null;
			}

			if (LapButtonItem != null) {
				LapButtonItem.Dispose ();
				LapButtonItem = null;
			}

			if (StopButtonItem != null) {
				StopButtonItem.Dispose ();
				StopButtonItem = null;
			}
		}
	}
}
