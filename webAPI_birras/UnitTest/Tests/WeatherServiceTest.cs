using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using webAPI_birras.Services;

namespace webAPI_birras_UnitTest.Tests
{
    [TestClass]
    public class WeatherServiceTest
    {
        [TestMethod]
        public void WeatherService_CanForecastMaxForecast()
        {
            int Forecast = WeatherService.MaxForecast;

            JToken temp = WeatherService.getDailyForecast(Forecast);

            Assert.IsTrue(temp != null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void WeatherService_CantForecastMoreThanMaxForecast()
        {
            int Forecast = WeatherService.MaxForecast + 2;

            WeatherService.getDailyForecast(Forecast);            
        }

    }
}
