using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using SaudeAPI.Configs;
using SaudeAPI.Context;
using SaudeAPI.Services;
using SaudeAPI.Services.Interfaces;

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
        }

        public static void ConfigureDB(IServiceCollection services, string connectionString)
        {
            services.AddDbContext<SaudeContext>(options => options.UseMySql(connectionString));
        }

        public static void ConfigureServices(IServiceCollection services)
        {
            services.TryAddTransient<IAuthService, AuthService>();
            services.TryAddTransient<ILogService, LogService>();

            services.AddControllers().AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            });
        }
    }
}