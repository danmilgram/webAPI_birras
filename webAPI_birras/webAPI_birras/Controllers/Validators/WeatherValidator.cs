using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webAPI_birras.Services;

namespace webAPI_birras.Controllers.Validators
{
    public class WeatherValidator
    {
        public static string CanForecast(DateTime date)
        {
            int daydiff = Convert.ToInt32((date - DateTime.Now.Date).Days);
            if (daydiff < 0 || daydiff > WeatherService.MaxForecast)
            {
                return WeatherValidatorMessage.emptyForecast;
            }
            else
            {
                return WeatherValidatorMessage.weatherOk;
            }
        }
    }
}
