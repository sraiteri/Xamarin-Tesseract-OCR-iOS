using System;
using ObjCRuntime;

[assembly: LinkWith ("libTesseractiOS.a", LinkTarget.Simulator | LinkTarget.Simulator64 | LinkTarget.ArmV7 | LinkTarget.ArmV7s | LinkTarget.Arm64, SmartLink = true, ForceLoad = true, IsCxx = true, Frameworks = "CoreFoundation CoreImage", LinkerFlags = "-ObjC -lstdc++")]
