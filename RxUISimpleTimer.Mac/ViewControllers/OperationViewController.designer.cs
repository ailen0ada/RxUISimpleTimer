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
	[Register ("OperationViewController")]
	partial class OperationViewController
	{
		[Outlet]
		AppKit.NSTextField CurrentValueField { get; set; }

		[Outlet]
		AppKit.NSButton RapButton { get; set; }

		[Outlet]
		AppKit.NSButton StartButton { get; set; }

		[Outlet]
		AppKit.NSButton StopButton { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (StartButton != null) {
				StartButton.Dispose ();
				StartButton = null;
			}

			if (RapButton != null) {
				RapButton.Dispose ();
				RapButton = null;
			}

			if (StopButton != null) {
				StopButton.Dispose ();
				StopButton = null;
			}

			if (CurrentValueField != null) {
				CurrentValueField.Dispose ();
				CurrentValueField = null;
			}
		}
	}
}
