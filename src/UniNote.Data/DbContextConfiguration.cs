using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SoftDeleteServices.Configuration;

namespace UniNote.Data;

public static class DbContextConfiguration
{
    public static IServiceCollection ConfigureDbContext(this IServiceCollection services, string connectionString)
    {
        Console.WriteLine($"CONNECTION STRING[DEBUG]:{connectionString}");
        services.AddDbContext<AppDbContext>(options =>
            options.UseNpgsql(connectionString,
                    x => x.MigrationsAssembly("UniNote.Api"))
                .UseSnakeCaseNamingConvention()
        );

        services.RegisterSoftDelServicesAndYourConfigurations(
            Assembly.GetAssembly(typeof(SoftDeleteConfiguration)));

        return services;
    }
}