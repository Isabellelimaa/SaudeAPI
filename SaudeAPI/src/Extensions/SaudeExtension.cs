using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Logging;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection.Extensions;
using SaudeAPI.Configs;
using SaudeAPI.Context;
using SaudeAPI.Services;
using SaudeAPI.Services.Interfaces;
using SaudeAPI.Configurations;

namespace SaudeAPI.Extensions
{
    public static class SaudeExtension
    {
        public static void ConfigureStartup(this IServiceCollection services, IConfiguration configuration)
        {
            services.TryAddSingleton<Constantes>();

            // Build an intermediate service provider
            var sp = services.BuildServiceProvider();

            // Resolve the services from the service provider
            var constantsService = sp.GetService<Constantes>();

            ConfigureDB(services, constantsService.MySQLConnection);
            ConfigureServices(services);
            ConfigureToken(services, configuration);
        }

        public static void ConfigureDB(IServiceCollection services, string connectionString)
        {
            services.AddDbContext<SaudeContext>(options => options.UseMySql(connectionString));
        }

        public static void ConfigureServices(IServiceCollection services)
        {
            services.TryAddTransient<CryptoConfigurations>();
            services.TryAddTransient<ITokenService, TokenService>();

            services.TryAddTransient<IAuthService, AuthService>();
            services.TryAddTransient<ILogService, LogService>();

            services.AddControllers().AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            });
        }

        public static void ConfigureToken(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMemoryCache();
            IdentityModelEventSource.ShowPII = true;
            var signingConfigurations = new SigningConfigurations();
            var recoverConfigurations = new RecoverConfigurations();

            services.TryAddSingleton(signingConfigurations);
            services.TryAddSingleton(recoverConfigurations);

            var tokenConfigurations = new TokenConfigurations()
            {
                Audience = "SaudeAPISDK",
                Issuer = "SaudeAPISDK",
                Seconds = 120,
                FinalExpiration = 240
            };

            services.TryAddSingleton(tokenConfigurations);

            services.AddAuthentication(authOptions =>
            {
                authOptions.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                authOptions.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(bearerOptions =>
            {
                var paramsValidation = bearerOptions.TokenValidationParameters;
                paramsValidation.IssuerSigningKey = signingConfigurations.Key;
                paramsValidation.ValidAudience = tokenConfigurations.Audience;
                paramsValidation.ValidIssuer = tokenConfigurations.Issuer;
                paramsValidation.ValidateIssuerSigningKey = true;
                paramsValidation.ValidateLifetime = true;
                paramsValidation.ClockSkew = TimeSpan.Zero;
            });

            services.AddAuthorization(auth =>
            {
                auth.AddPolicy("Bearer", new AuthorizationPolicyBuilder()
                    .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme)
                    .RequireAuthenticatedUser().Build());
            });
        }
    }
}