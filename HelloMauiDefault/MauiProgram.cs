using CommunityToolkit.Maui;
using CommunityToolkit.Maui.Markup;
using HelloMauiDefault.Handlers;
using HelloMauiDefault.Pages;
using HelloMauiDefault.ViewModels;
using HelloMauiDefault.Views;
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
                .ConfigureMauiHandlers(handlers =>
                {
                    handlers.AddHandler<CalendarView, CalendarHandler>();
                })
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

            builder.Services.AddTransient<ListPage, ListViewModel>();
            builder.Services.AddTransient<DetailsPage, DetailsViewModel>();
            builder.Services.AddTransient<Views.CalendarView>();

            return builder.Build();
        }
    }
}
