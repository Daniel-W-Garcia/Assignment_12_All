﻿using MAUI_Demo.ViewModels;
using MAUI_Demo.Views;
using Microsoft.Extensions.Logging;

namespace MAUI_Demo;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });
        builder.Services.AddSingleton<MainPage>();
        builder.Services.AddSingleton<MainViewModel>();
        builder.Services.AddTransient<DetailViewModel>();
        builder.Services.AddTransient<DetailPage>();
        builder.Services.AddSingleton<IConnectivity>(Connectivity.Current);

#if DEBUG
        builder.Logging.AddDebug();
        
#endif

        return builder.Build();
    }
}