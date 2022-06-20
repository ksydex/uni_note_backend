using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using UniNote.Api;

var host =  CreateHostBuilder(args).Build();

using var scope = host.Services.CreateScope();
var services = scope.ServiceProvider;

try
{
    var context = services.GetRequiredService<DbContext>();
    var pendingMigrations = context.Database.GetPendingMigrations().ToList();
    context.Database.Migrate();

    // SeedData.Initialize(services); // is not async, so DbContext will be disposed for the time
}
catch (Exception ex)
{
    var logger = services.GetRequiredService<ILogger<Program>>();
    logger.LogError(ex, "An error occurred seeding the DB");
}

host.Run();

static IHostBuilder CreateHostBuilder(string[] args) =>
    Host.CreateDefaultBuilder(args)
        .UseServiceProviderFactory(new AutofacServiceProviderFactory())
        .ConfigureWebHostDefaults(webBuilder =>
        {
            webBuilder
                .UseStartup<Startup>()
                .ConfigureLogging(logging =>
                {
                    logging.ClearProviders();
                    logging.AddConsole();
                    // logging.AddAzureWebAppDiagnostics(); add this if deploying to Azure
                });
        });