using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using webAPI_birras.Models;
using webAPI_birras.Services;
namespace webAPI_birras.Infrastructure
{
    public class ConfigureMongo
    {
        public static void ConfigMongo(IConfiguration config, IServiceCollection services)
        {
            _ConfigMongo(config, services);
        }

        private static void _ConfigMongo(IConfiguration config, IServiceCollection services)
        {
            //CONFIGURO  BIRRAS MONGO DATABASE
            services.Configure<BirrasDatabaseSettings>(
                config.GetSection(nameof(BirrasDatabaseSettings)));
            
            services.AddSingleton<IBirrasDatabaseSettings>(sp =>
                sp.GetRequiredService<IOptions<BirrasDatabaseSettings>>().Value);
        }
    }
}
