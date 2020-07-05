using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using webAPI_birras.Controllers.Validators;
using webAPI_birras.Services;

namespace webAPI_birras_UnitTest.Tests
{
    [TestClass]
    class WeatherValidatorTest
    {
        [TestMethod]
        public void MeetUpWeatherValidation_EmptyForecast()
        {

            int days = WeatherService.MaxForecast + 1;
            string msg = WeatherValidator.CanForecast(DateTime.Now.AddDays(days));

            Assert.IsTrue(msg == WeatherValidatorMessage.emptyForecast);
        }

        [TestMethod]
        public void MeetUpWeatherValidation_weatherOk()
        {
            int days = WeatherService.MaxForecast;
            string msg = WeatherValidator.CanForecast(DateTime.Now.AddDays(days));

            Assert.IsTrue(msg == WeatherValidatorMessage.weatherOk);
        }
    }
}
