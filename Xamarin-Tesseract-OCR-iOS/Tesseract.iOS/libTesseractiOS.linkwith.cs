using System;
using MonoTouch.ObjCRuntime;

[assembly: LinkWith ("libTesseractiOS.a", LinkTarget.ArmV7 | LinkTarget.ArmV7s | LinkTarget.Simulator, ForceLoad = true, Frameworks = "CoreGraphics", IsCxx = true)]
