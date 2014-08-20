// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using MonoTouch.Foundation;
using System.CodeDom.Compiler;

namespace Tesseract.iOSSample
{
	[Register ("TesseractViewController")]
	partial class TesseractViewController
	{
		[Outlet]
		MonoTouch.UIKit.UIButton RecogniseExistingImage_Button { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton TakePicture_Button { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (TakePicture_Button != null) {
				TakePicture_Button.Dispose ();
				TakePicture_Button = null;
			}

			if (RecogniseExistingImage_Button != null) {
				RecogniseExistingImage_Button.Dispose ();
				RecogniseExistingImage_Button = null;
			}
		}
	}
}
