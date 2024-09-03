using Microsoft.Extensions.Logging;
#if ANDROID
using CameraWebViewApp.Clients;
#endif

namespace CameraWebViewApp;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
#if ANDROID
    Microsoft.Maui.Handlers.WebViewHandler.Mapper.Add("WebChromeClient", (handler, view) =>
    {
        handler.PlatformView.SetWebChromeClient(new AndroidChromeClient());
    });
#elif WINDOWS
#elif IOS
#endif
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}
