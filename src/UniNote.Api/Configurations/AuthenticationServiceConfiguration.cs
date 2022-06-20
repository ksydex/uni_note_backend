using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using UniNote.Api.Extensions;

namespace UniNote.Api.Configurations;

public static class AuthenticationServiceConfiguration
{
    public static IServiceCollection ConfigureCustomAuthentication(this IServiceCollection services,
        IConfiguration configuration)
    {
        var key = services.GetHashedKey(configuration);
        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true
                };

                x.Events = new JwtBearerEvents
                {
                    OnMessageReceived = context =>
                    {
                        if (context.HttpContext.Request.Path.ToString().Contains("/hub"))
                        {
                            var jwt = context.Request.Query["access_token"].FirstOrDefault();

                            if (!string.IsNullOrEmpty(jwt))
                                context.Token = jwt;
                        }

                        return Task.CompletedTask;
                    }
                };
            });

        return services;
    }
}