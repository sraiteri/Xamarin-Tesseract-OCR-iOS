using System;

using UIKit;
using Foundation;
using ObjCRuntime;
using CoreGraphics;

namespace Tesseract.iOS
{
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

