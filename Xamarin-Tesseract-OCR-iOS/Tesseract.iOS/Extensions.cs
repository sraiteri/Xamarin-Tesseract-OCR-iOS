using MonoTouch.Foundation;
using System.Threading.Tasks;

namespace Tesseract.iOS
{
	public partial class Tesseract : NSObject
	{
		public Task<string> RecognizeAsync ()
		{
			return Task.Factory.StartNew (() =>
            {
                return Recognize() ? RecognizedText : string.Empty;
            });
		}
	}
}

