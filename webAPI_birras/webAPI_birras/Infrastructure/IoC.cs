using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webAPI_birras.Services;

namespace webAPI_birras.Infrastructure
{
    public static class IoC
    {
        public static IServiceCollection addRegistration(this IServiceCollection services)
        {
            //SINGLETON DE CADA SERVICIO DE MVC
            services.AddSingleton<UserService>();
            services.AddSingleton<MeetUpService>();
            services.AddSingleton<AuthService>();
            services.AddSingleton<NotificationService>();

            services.AddControllers();

            return services;
        }


    }
}
