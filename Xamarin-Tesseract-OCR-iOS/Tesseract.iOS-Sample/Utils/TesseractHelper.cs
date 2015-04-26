
namespace Tesseract.iOSSample
{
	public static class TesseractHelper
	{
		public static Tesseract.iOS.Tesseract CreateTesseract(string languages = "eng") 
		{
			//Initalise the tesseract object - using tessdata as default (path to the training data in the binding project), with eng ("English")
			//as the default language
			return new Tesseract.iOS.Tesseract (languages);
		}
	}
}

