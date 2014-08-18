using System;
using System.Drawing;

using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.IO;

namespace Tesseract.iOSSample
{
	public partial class TesseractViewController : UIViewController
	{
		public TesseractViewController () : base ("TesseractViewController", null)
		{
		}
			
		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			
			//Initalise the tesseract object - using tessdata (path to the training data in the binding project), with eng ("English")
			//as the language
			var tesseractOcr = new Tesseract.iOS.Tesseract ("tessdata", "eng");

			//Set the image to be scanned for text (added as a BundleResource)
			tesseractOcr.SetImage (UIImage.FromBundle ("test-image.jpeg"));

			//Recognise text in the scanned image - sync method called here, but can be async
			//Text is: "The quick brown fox jumped over the Lazy dog"
			tesseractOcr.Recognize ();

			//Show the recognised text in a UIAlertView
			new UIAlertView ("Recognised text", tesseractOcr.RecognizedText, null, "OK").Show ();

		}
	}
}

