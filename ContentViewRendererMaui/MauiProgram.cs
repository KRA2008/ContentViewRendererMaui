#if __ANDROID__
using ContentViewRendererMaui.Platforms.Android;
#endif
using Microsoft.Extensions.Logging;

namespace ContentViewRendererMaui
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureMauiHandlers(handlers =>
                {
#if __ANDROID__
                    handlers.AddHandler<MyContentView,MyContentViewRenderer>();
#endif
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
