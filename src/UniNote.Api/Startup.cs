using Autofac;
using Microsoft.Extensions.Options;
using UniNote.Api.Extensions;
using UniNote.Core.Helpers;

namespace UniNote.Api;

public class Startup
{
    private IWebHostEnvironment Env { get; }
    public IConfiguration Configuration { get; }

    public Startup(IConfiguration configuration, IWebHostEnvironment env)
    {
        Configuration = StartupExtensions.CreateConfiguration(configuration, env);
        Env = env;
    }

    public void ConfigureServices(IServiceCollection services)
        => services.ConfigureServices(Configuration, Env);

    public void ConfigureContainer(ContainerBuilder builder)
        => StartupExtensions.ConfigureContainer(builder, Env);

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IOptions<AppSettings> appSettings)
        => app.Configure(env, appSettings);
}