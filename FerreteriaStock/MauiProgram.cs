using FerreteriaStock.Services;
using FerreteriaStock;
using Microsoft.Extensions.Logging;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>() // Esta es la App de App.xaml.cs (MAUI)
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
            });

        builder.Services.AddMauiBlazorWebView();

        // Servicios propios
        builder.Services.AddSingleton<SesionUsuario>();
        builder.Services.AddScoped<UsuarioService>();
        builder.Services.AddScoped<ProductoService>();

        // Configuración de HttpClient según plataforma
        string baseApiUrl;

#if ANDROID
        baseApiUrl = "https://localhost:7208"; // Para emulador Android (10.0.2.2 redirige a localhost de tu PC)
#else
        baseApiUrl = "https://localhost:7208"; // Para Windows/iOS en tu PC
#endif

        builder.Services.AddScoped(sp => new HttpClient
        {
            BaseAddress = new Uri(baseApiUrl)
        });

#if DEBUG
        builder.Services.AddBlazorWebViewDeveloperTools();
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}
