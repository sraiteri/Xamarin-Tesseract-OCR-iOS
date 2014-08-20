using System;

using MonoTouch.UIKit;
using MBProgressHUD;

namespace Tesseract.iOSSample
{
	public partial class TesseractViewController : UIViewController
	{
		UIImagePickerController _imagePickerController;
		readonly PickerDelegate _pickerDelegate;

		public TesseractViewController () : base ("TesseractViewController", null)
		{
			_pickerDelegate = new PickerDelegate (this);
		}
			
		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			Title = "Tesseract OCR";

			//Wire in the buttons
			RecogniseExistingImage_Button.TouchUpInside += HandleRecogniseExistingImageButtonPressed;;
			TakePicture_Button.TouchUpInside += HandleTakePictureButtonPressed;
		}

		void HandleRecogniseExistingImageButtonPressed (object sender, EventArgs e)
		{
			ExtractResults (UIImage.FromBundle ("test-image.jpeg"));
		}

		public async void ExtractResults(UIImage image)
		{
			var loader = LoaderHelper.CreateLoaderForView (View);

			loader.Show (true);

			var tesseract = TesseractHelper.CreateTesseract ();
			tesseract.SetImage (image);
			var recognisedText = await tesseract.RecognizeAsync ();

			loader.Hide (true);


			new UIAlertView ("Text extracted from image", recognisedText, null, "OK").Show ();
		}

		void HandleTakePictureButtonPressed (object sender, System.EventArgs e)
		{
			try {

				_imagePickerController = new UIImagePickerController ();

				//Assign the delegate for the controller
				_imagePickerController.Delegate = _pickerDelegate;

				_imagePickerController.SourceType = UIImagePickerControllerSourceType.Camera;
				_imagePickerController.MediaTypes = UIImagePickerController.AvailableMediaTypes 
					(UIImagePickerControllerSourceType.Camera);

				// show the camera controls
				_imagePickerController.ShowsCameraControls = true;

				NavigationController.PresentViewController (_imagePickerController, true, null);
			} catch (Exception) {
				var alert = new UIAlertView ("No Camera", "No Camera Detected on the device", null, "OK", null);
				alert.Show ();
			}
		}
	}
}

