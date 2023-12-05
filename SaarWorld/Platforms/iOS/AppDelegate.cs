// ---------------------------------------------------------------
// Copyright (c) 2023 Mabrouk Mahdhi. All rights reserved.
// This is a prototype implementing eCommerce app using .NET MAUI
// ---------------------------------------------------------------

using Foundation;
using Microsoft.Maui;
using Microsoft.Maui.Hosting;

namespace SaarWorld;

[Register("AppDelegate")]
public class AppDelegate : MauiUIApplicationDelegate
{
    protected override MauiApp CreateMauiApp() =>
        MauiProgram.CreateMauiApp();
}