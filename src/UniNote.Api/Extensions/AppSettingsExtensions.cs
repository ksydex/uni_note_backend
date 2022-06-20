using System.Text;
using UniNote.Core.Helpers;

namespace UniNote.Api.Extensions;

public static class AppSettingsExtensions
{
    public static IServiceCollection ConfigureAppSettings(this IServiceCollection services,
        IConfiguration configuration)
    {
        var appSettingsSection = configuration.GetSection(AppSettings.Key);
        services.Configure<AppSettings>(appSettingsSection);
        var appSettings = appSettingsSection.Get<AppSettings>();
        AppSettings.Singleton = appSettings;
        return services;
    }

    public static byte[] GetHashedKey(this IServiceCollection serviceCollection, IConfiguration configuration)
    {
        var appSettings = configuration.GetSection(AppSettings.Key).Get<AppSettings>();
        return Encoding.ASCII.GetBytes(appSettings.SecretKey);
    }
}