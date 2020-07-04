using Newtonsoft.Json.Linq;
using RestSharp;

namespace webAPI_birras.Services
{
    public class WeatherService
    {
        public static readonly int MaxForecast = 7;

        public static JToken getDailyForecast(int days)
        {
            try
            {
                var client = new RestClient("https://api.openweathermap.org/data/2.5/onecall?lat=-34.6&lon=-58.43&exclude=minutely,hourly&units=metric&&APPID=e2c81d202f7205dd8dedf09c83a517f9");
                var request = new RestRequest(Method.GET);

                IRestResponse response = client.Execute(request);

                JObject jObject = JObject.Parse(response.Content);
                JArray daily = (JArray)jObject.SelectToken("daily");

                return daily[days].SelectToken("temp");
            }
            catch (System.Exception e)
            {
                throw e;
            }
        }

    }
}
