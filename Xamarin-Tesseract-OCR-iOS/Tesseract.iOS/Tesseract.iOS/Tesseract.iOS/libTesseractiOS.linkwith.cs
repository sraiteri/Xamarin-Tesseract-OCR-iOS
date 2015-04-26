using System;
using ObjCRuntime;

[assembly: LinkWith ("libTesseractiOS.a", LinkTarget.ArmV7 | LinkTarget.Arm64, SmartLink = true, ForceLoad = true, IsCxx = true, Frameworks = "CoreFoundation CoreImage", LinkerFlags = "-ObjC -lstdc++")]
