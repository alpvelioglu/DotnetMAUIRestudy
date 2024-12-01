using CommunityToolkit.Maui;
using CommunityToolkit.Maui.Markup;
using HelloMauiDefault.Pages;
using HelloMauiDefault.ViewModels;
using Microsoft.Extensions.Logging;

namespace HelloMauiDefault
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .UseMauiCommunityToolkitMarkup()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif
            builder.Services.AddSingleton<AppShell>();
            builder.Services.AddSingleton<App>();

            builder.Services.AddTransient<ListPage>();
            builder.Services.AddTransient<DetailsPage>();
            builder.Services.AddTransient<DetailsViewModel>();
            builder.Services.AddTransient<ListViewModel>();

            return builder.Build();
        }
    }
}
