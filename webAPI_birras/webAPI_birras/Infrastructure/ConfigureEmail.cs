using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webAPI_birras.Services;

namespace webAPI_birras.Infrastructure
{
    public class ConfigureEmail
    {
        public static void ConfigEMail(IConfiguration config)
        {
            _ConfigEmail(config);
        }
        
        private static void _ConfigEmail(IConfiguration configuration)
        {
            EmailService.emailConfigurationSmtpServer = configuration["EmailConfiguration:SmtpServer"];
            EmailService.emailConfigurationSmtpPort =Convert.ToInt32( configuration["EmailConfiguration:SmtpPort"]);
            EmailService.emailConfigurationSmtpUsername = configuration["EmailConfiguration:SmtpUsername"];
            EmailService.emailConfigurationSmtpPassword = configuration["EmailConfiguration:SmtpPassword"];
        }
    }
}
