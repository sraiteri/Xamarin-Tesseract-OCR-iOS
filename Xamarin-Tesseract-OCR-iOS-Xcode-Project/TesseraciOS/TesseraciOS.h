//
//  TesseraciOS.h
//  TesseraciOS
//
//  Created by Alex Soto on 03/05/13.
//  Copyright (c) 2013 Alex Soto. All rights reserved.
//

#import <Foundation/Foundation.h>
#import <UIKit/UIKit.h>

@interface Tesseract : NSObject {
    NSString* _dataPath;
    NSString* _language;
    NSMutableDictionary* _variables;
}

+ (NSString *)version;

- (id)initWithDataPath:(NSString *)dataPath language:(NSString *)language;
- (void)setVariableValue:(NSString *)value forKey:(NSString *)key;
- (void)setImage:(UIImage *)image;
- (BOOL)setLanguage:(NSString *)language;
- (BOOL)recognize;
- (NSString *)recognizedText;

@end
