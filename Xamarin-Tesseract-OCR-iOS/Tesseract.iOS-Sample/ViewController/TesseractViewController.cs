using System;

using MonoTouch.UIKit;
using MBProgressHUD;
using System.Drawing;
using MonoTouch.CoreGraphics;

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

		public async void ExtractResults(UIImage image, bool preProcessImage = false)
		{
			UIImage imageToBeProcessed = image;

			if (preProcessImage)
				imageToBeProcessed = PreProcessImage (image);

			LastImage_ImageView.Image = imageToBeProcessed;

			var loader = LoaderHelper.CreateLoaderForView (View);

			loader.Show (true);

			var tesseract = TesseractHelper.CreateTesseract ();
			tesseract.SetImage (imageToBeProcessed);
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


		//Image processing functions
		UIImage PreProcessImage(UIImage image)
		{
			//Do some pre-processing to the image. For tesseract, image recognition (and speed) is better if:
			//1. Image is in black & white (or at least greyscale)
			//2. Image is portrait (top to bottom, left to right)
			//3. Image aspect ratio is maintained (higher quality images are better, but take longer to process)

			//TODO: These steps can be extended much further (and done better), but this is just a general gist.
			var scaledImage = ScaleImage (image);
			var greyscaleImage = ConvertToGrayScale (scaledImage);

			//return greyscaleImage;
			return ForceImagePortrait (greyscaleImage);
		}

		UIImage ConvertToGrayScale (UIImage image)
		{
			var imageRect = new RectangleF (PointF.Empty, image.Size);
			using (var colorSpace = CGColorSpace.CreateDeviceGray ())
			using (var context = new CGBitmapContext (IntPtr.Zero, (int) imageRect.Width, (int) imageRect.Height, 8, 0, colorSpace, CGImageAlphaInfo.None)) {
				context.DrawImage (imageRect, image.CGImage);
				using (var imageRef = context.ToImage ())
					return ForceImagePortrait(new UIImage (imageRef));
			}
		}

		UIImage ScaleImage(UIImage image)
		{
			//Picking default iPhone 4 size
			var newRect = new RectangleF(0,0, 320f, 480f);
			UIGraphics.BeginImageContextWithOptions(newRect.Size, false, 0.0f);
			image.Draw (newRect);
			var scaledImage = UIGraphics.GetImageFromCurrentImageContext ();
			UIGraphics.EndImageContext ();

			return scaledImage;
		}

		UIImage ForceImagePortrait(UIImage image)
		{
			const float M_PI = 3.14159265359f;

			CGAffineTransform rectTransform = CGAffineTransform.MakeIdentity();
			switch (image.Orientation)
			{
			case UIImageOrientation.Left:
				rectTransform = CGAffineTransform.Translate(CGAffineTransform.MakeRotation(M_PI * 2), 0, -image.Size.Height);
				break;
			case UIImageOrientation.Right:
				rectTransform = CGAffineTransform.Translate(CGAffineTransform.MakeRotation(-(M_PI * 2)), -image.Size.Width, 0);
				break;
			case UIImageOrientation.Down:
				rectTransform = CGAffineTransform.Translate(CGAffineTransform.MakeRotation(-M_PI), -image.Size.Width, 
					-image.Size.Height);
				break;
			};
			rectTransform = CGAffineTransform.Scale(rectTransform, image.CurrentScale, image.CurrentScale);

			image.CGImage.WithImageInRect (CGAffineTransform.CGRectApplyAffineTransform (
				new RectangleF(0,0, image.Size.Width, image.Size.Height), rectTransform));

			var portraitImage = UIImage.FromImage (image.CGImage, image.CurrentScale, image.Orientation);

			return portraitImage;
		}
	}
}

