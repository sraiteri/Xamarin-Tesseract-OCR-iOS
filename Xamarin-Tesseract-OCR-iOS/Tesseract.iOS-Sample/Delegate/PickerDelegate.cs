using System;
using UIKit;
using Foundation;
using CoreGraphics;
using CoreGraphics;

namespace Tesseract.iOSSample
{
	// Our custom picker delegate. The events haven't been exposed so we have to use a 
	// delegate.
	public class PickerDelegate : UIImagePickerControllerDelegate
	{
		TesseractViewController _parentViewController;

		public PickerDelegate(TesseractViewController parentViewController) : base()
		{
			_parentViewController = parentViewController;
		}

		public override void Canceled (UIImagePickerController picker)
		{
			//Dismiss the picker
			picker.DismissViewController (true, null);
		}
			
		public override void FinishedPickingMedia (UIImagePickerController picker, NSDictionary info)
		{
			//Determine that an image was selected
			bool isImage = false;
			switch (info [UIImagePickerController.MediaType].ToString ()) {
			case "public.image":
				isImage = true;
				break;
			}

			//If it was an image, get the image
			if (isImage) {
				//Get the image - either it will be original, or edited
				var originalImage = info [UIImagePickerController.OriginalImage] as UIImage;
				var editedImage = info [UIImagePickerController.EditedImage] as UIImage;

				UIImage image = null;
				if (originalImage != null)
					image = originalImage;
				else if (editedImage != null)
					image = editedImage;

				picker.DismissViewController (false, () => _parentViewController.ExtractResults (image, true));
				return;
			}

			picker.DismissViewController (false, 
				() => new UIAlertView ("Image not processed", "Image could not be processed", null, "OK").Show ());
		}
			
	}
}

