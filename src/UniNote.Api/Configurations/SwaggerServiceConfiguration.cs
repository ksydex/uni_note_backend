using System.Reflection;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace UniNote.Api.Configurations;

public static class SwaggerServiceConfiguration
{
    private const string TitleBase = "Flowyard X";
    private const string Description = "Web API documentation ";

    private static readonly List<OpenApiInfo> Versions = new()
    {
        new OpenApiInfo
        {
            Version = "v1",
            Title = TitleBase + " v1",
            Description = Description
        }
    };

    public static IServiceCollection ConfigureSwaggerService(this IServiceCollection services)
    {
            
        services.AddSwaggerGen(config =>
        {
            foreach (var v in Versions)
            {
                config.SwaggerDoc(v.Version, v);
            }

            config.EnableAnnotations();
                
            config.AddSecurityDefinition("bearer", new OpenApiSecurityScheme
            {
                Type = SecuritySchemeType.Http,
                BearerFormat = "JWT",
                In = ParameterLocation.Header,
                Scheme = "bearer"
            });

            config.OperationFilter<AuthenticationRequirementsOperationFilter>();
            // config.DocumentFilter<RemoveEntitySchemasDocumentFilter>();

            var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
            config.IncludeXmlComments(xmlPath);
        });

        services.AddSwaggerGenNewtonsoftSupport();

        return services;
    }

    public static IApplicationBuilder UseSwaggerWithCustomConfiguration(this IApplicationBuilder app)
    {
        app.UseSwagger()
            .UseSwaggerUI(config =>
            {
                config.DocExpansion(DocExpansion.None);
                foreach (var v in Versions)
                {
                    config.SwaggerEndpoint($"/swagger/{v.Version}/swagger.json", v.Title);
                    config.ConfigObject.AdditionalItems.Add("syntaxHighlight",
                        false); //Turns off syntax highlight which causing performance issues...
                    config.ConfigObject.AdditionalItems.Add("theme",
                        "agate"); //Reverts Swagger UI 2.x  theme which is simpler not much performance benefit...
                }
            });
        return app;
    }

    private class AuthenticationRequirementsOperationFilter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            operation.Security ??= new List<OpenApiSecurityRequirement>();

            var scheme = new OpenApiSecurityScheme
                { Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "bearer" } };
            operation.Security.Add(new OpenApiSecurityRequirement
            {
                [scheme] = new List<string>()
            });
        }
    }
}