using System.Threading.Tasks;
using Foundation;

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

