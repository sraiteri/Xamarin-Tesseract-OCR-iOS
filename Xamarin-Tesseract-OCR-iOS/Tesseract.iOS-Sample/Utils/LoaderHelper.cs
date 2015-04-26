using UIKit;
using MBProgressHUD;

namespace Tesseract.iOSSample
{
	public static class LoaderHelper
	{
		public static MTMBProgressHUD CreateLoaderForView(UIView view)
		{
			var hud = new MTMBProgressHUD (view) {
				LabelText = "Recognising text in image...",
				RemoveFromSuperViewOnHide = true
			};

			view.AddSubview (hud);

			return hud;
		}
	}
}

