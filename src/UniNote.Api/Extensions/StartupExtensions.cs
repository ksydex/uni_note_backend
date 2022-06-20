using System.Net;
using System.Text.Json;
using System.Text.Json.Serialization;
using Autofac;
using FastEndpoints;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using UniNote.Api.Configurations;
using UniNote.Api.Middlewares;
using UniNote.Application;
using UniNote.Core.Constants;
using UniNote.Core.Helpers;
using UniNote.Data;

namespace UniNote.Api.Extensions;

public static class StartupExtensions
{
    public static class DbConnectionStringKey
    {
        public static class Default
        {
            public const string Docker = "DefaultDocker";
            public const string Local = "DefaultLocal";
            public const string Test = "TestLocal";
        }
    }

    public static void ConfigureServices(this IServiceCollection services, IConfiguration configuration,
        IWebHostEnvironment env)
    {
        string GetDbConnectionString()
            => AppSettings.Singleton.Environment switch
            {
                EnvironmentTypes.Test => DbConnectionStringKey.Default.Test,
                _ when env.IsProduction() => DbConnectionStringKey.Default.Docker,
                _ when !env.IsProduction() => DbConnectionStringKey.Default.Local,
                _ => throw new Exception("No connection string found")
            };


        services.AddSignalR();

        services
            .ConfigureAppSettings(configuration)
            .ConfigureHeadersAndCookie()
            .AddFastEndpoints()
            .ConfigureSwaggerService()
            .ConfigureCustomAuthentication(configuration)
            .ConfigureDbContext(configuration.GetConnectionString(GetDbConnectionString()))
            .ConfigureCors();
        // .AddControllers()
        // services.AddNewtonsoftJson(options =>
        // {
        //     options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
        //     options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
        //     options.SerializerSettings.DateTimeZoneHandling = DateTimeZoneHandling.Utc;
        // });

        services.AddHttpContextAccessor();
    }

    public static void Configure(this IApplicationBuilder app, IWebHostEnvironment env,
        IOptions<AppSettings> appSettings)
    {
        // disables certificate validation
        ServicePointManager.ServerCertificateValidationCallback = (_, _, _, _) => true;

        app
            // .UseExceptionMiddleware()
            .UseCors();
        if (env.EnvironmentName == "Development")
            app.UseDeveloperExceptionPage();
        else
        {
            app.UseExceptionHandler("/Home/Error");
            app.UseHsts();
        }

        app.UseMiddleware<ErrorHandlerMiddleware>();
        app.UseCustomStaticFiles()
            .UseForwardedHeaders()
            .UseHttpsRedirection()
            .UseRouting()
            .UseAuthentication()
            .UseAuthorization()
            .UseFastEndpointsMiddleware()
            .UseEndpoints(endpoints =>
            {
                // endpoints.MapDefaultControllerRoute();
                endpoints.MapFastEndpoints(c =>
                {
                    c.RoutingOptions = o => o.Prefix = "api";
                    c.SerializerOptions = o =>
                    {
                        o.ReferenceHandler = ReferenceHandler.IgnoreCycles;
                        o.PropertyNameCaseInsensitive = true;
                    };
                });
            })
            .UseSwaggerWithCustomConfiguration();
    }


    public static void ConfigureContainer(ContainerBuilder builder, IWebHostEnvironment env)
    {
        builder.RegisterModule(new DefaultApplicationModule(env.EnvironmentName == "Development"));
        // builder.RegisterModule(new DefaultCoreModule());
        // builder.RegisterModule(new DefaultWebModule());
    }

    public static IConfiguration CreateConfiguration(IConfiguration configuration, IWebHostEnvironment env)
    {
        var builder = new ConfigurationBuilder()
            .AddJsonFile("config.json", !env.IsProduction())
            .AddEnvironmentVariables()
            .AddConfiguration(configuration);

        return builder.Build();
    }

    public static IApplicationBuilder UseCustomStaticFiles(this IApplicationBuilder app)
    {
        const string dir = "static";
        var path = Path.Combine(Directory.GetCurrentDirectory(), dir);
        Directory.CreateDirectory(path);

        app.UseStaticFiles(
            new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(
                    Path.Combine(Directory.GetCurrentDirectory(), dir)),
                RequestPath = new PathString("/static"),
                ServeUnknownFileTypes = true,
                OnPrepareResponse = ctx =>
                    ctx.Context.Response.Headers.Append(
                        "Cache-Control", $"public, max-age={604800}")
            }
        );

        return app;
    }


    public static IServiceCollection ConfigureHeadersAndCookie(this IServiceCollection services)
    {
        services.Configure<ForwardedHeadersOptions>(options =>
            {
                options.ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto;
                options.KnownNetworks.Clear();
                options.KnownProxies.Clear();
            })
            .Configure<CookiePolicyOptions>(options =>
            {
                options.CheckConsentNeeded = _ => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });
        return services;
    }
}