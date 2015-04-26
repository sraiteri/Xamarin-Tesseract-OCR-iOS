using System;

using UIKit;
using Foundation;
using ObjCRuntime;
using CoreGraphics;

namespace Tesseract.iOS
{
	// The first step to creating a binding is to add your native library ("libNativeLibrary.a")
	// to the project by right-clicking (or Control-clicking) the folder containing this source
	// file and clicking "Add files..." and then simply select the native library (or libraries)
	// that you want to bind.
	//
	// When you do that, you'll notice that MonoDevelop generates a code-behind file for each
	// native library which will contain a [LinkWith] attribute. MonoDevelop auto-detects the
	// architectures that the native library supports and fills in that information for you,
	// however, it cannot auto-detect any Frameworks or other system libraries that the
	// native library may depend on, so you'll need to fill in that information yourself.
	//
	// Once you've done that, you're ready to move on to binding the API...
	//
	//
	// Here is where you'd define your API definition for the native Objective-C library.
	//
	// For example, to bind the following Objective-C class:
	//
	//     @interface Widget : NSObject {
	//     }
	//
	// The C# binding would look like this:
	//
	//     [BaseType (typeof (NSObject))]
	//     interface Widget {
	//     }
	//
	// To bind Objective-C properties, such as:
	//
	//     @property (nonatomic, readwrite, assign) CGPoint center;
	//
	// You would add a property definition in the C# interface like so:
	//
	//     [Export ("center")]
	//     CGPoint Center { get; set; }
	//
	// To bind an Objective-C method, such as:
	//
	//     -(void) doSomething:(NSObject *)object atIndex:(NSInteger)index;
	//
	// You would add a method definition to the C# interface like so:
	//
	//     [Export ("doSomething:atIndex:")]
	//     void DoSomething (NSObject object, int index);
	//
	// Objective-C "constructors" such as:
	//
	//     -(id)initWithElmo:(ElmoMuppet *)elmo;
	//
	// Can be bound as:
	//
	//     [Export ("initWithElmo:")]
	//     IntPtr Constructor (ElmoMuppet elmo);
	//
	// For more information, see http://developer.xamarin.com/guides/ios/advanced_topics/binding_objective-c/
	//

	// @interface Tesseract : NSObject
	[BaseType (typeof(NSObject)), DisableDefaultCtor]
	interface Tesseract
	{
		// +(NSString *)version;
		[Static]
		[Export ("version")]
		string Version { get; }

		// @property (nonatomic, strong) NSString * language;
		[Export ("language", ArgumentSemantic.Strong)]
		string Language { get; set; }

		// @property (nonatomic, strong) UIImage * image;
		[Export ("image", ArgumentSemantic.Strong)]
		UIImage Image { get; set; }

		// @property (assign, nonatomic) CGRect rect;
		[Export ("rect", ArgumentSemantic.Assign)]
		CGRect Rect { get; set; }

		// @property (readonly, nonatomic) short progress;
		[Export ("progress")]
		short Progress { get; }

		// @property (readonly, nonatomic) NSString * recognizedText;
		[Export ("recognizedText")]
		string RecognizedText { get; }

		// @property (readonly, nonatomic) NSArray * characterBoxes;
		[Export ("characterBoxes")]
		NSObject[] CharacterBoxes { get; }

		// @property (readonly, nonatomic) NSArray * getConfidenceByWord;
		[Export ("getConfidenceByWord")]
		NSObject[] ConfidenceByWord { get; }

		// @property (readonly, nonatomic) NSArray * getConfidenceBySymbol;
		[Export ("getConfidenceBySymbol")]
		NSObject[] ConfidenceBySymbol { get; }

		// @property (readonly, nonatomic) NSArray * getConfidenceByTextline;
		[Export ("getConfidenceByTextline")]
		NSObject[] ConfidenceByTextline { get; }

		// @property (readonly, nonatomic) NSArray * getConfidenceByParagraph;
		[Export ("getConfidenceByParagraph")]
		NSObject[] ConfidenceByParagraph { get; }

		// @property (readonly, nonatomic) NSArray * getConfidenceByBlock;
		[Export ("getConfidenceByBlock")]
		NSObject[] ConfidenceByBlock { get; }

		// -(id)initWithLanguage:(NSString *)language;
		[Export ("initWithLanguage:")]
		IntPtr Constructor (string language);

		// -(void)setVariableValue:(NSString *)value forKey:(NSString *)key;
		[Export ("setVariableValue:forKey:")]
		void SetVariableValue (string value, string key);

		// -(BOOL)recognize;
		[Export ("recognize")]
		bool Recognize();
	}
}

