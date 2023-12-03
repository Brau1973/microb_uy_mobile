using microb_uy_mobile.Pages.MainTenant.SearchPages;
using microb_uy_mobile.Services.Interfaces;
using microb_uy_mobile.ViewModels;
using Microsoft.Extensions.Logging;
using Refit;

namespace microb_uy_mobile
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
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            // ------------------------------ MAIN TENANT ------------------------------
            // HashTags
            //builder.Services.AddRefitClient<IHashTagService>();
            //builder.Services.AddSingleton<SearchHashtagsViewModel>();
            //builder.Services.AddSingleton<SearchHashtagsPage>();
#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}