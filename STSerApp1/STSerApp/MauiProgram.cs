﻿using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;


namespace STSerApp
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("Roboto-Regular.ttf", "RobotoRegular");
                    fonts.AddFont("Roboto-Bold.ttf", "RobotoBold");
                })
                .UseMauiCommunityToolkit();

#if DEBUG
		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }

        


    }
}