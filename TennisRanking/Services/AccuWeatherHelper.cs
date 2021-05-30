using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TennisRanking.Models.AccuWeather.Forecast;
using System.Net.Http;

namespace TennisRanking.Services
{
    public class AccuWeatherHelper
    {
        const string ACCUWEATHER_API_KEY = "mflRjG6fd68WFqEej1Auwrz7EQ2OT7MY";
        const string MEDIANEIRA_KEY = "40110";
        const string BASE_URL = "http://dataservice.accuweather.com/";
        const string LOCATIONS_ENDPOINT = "locations/v1/cities/autocomplete?apikey={0}&q={1}";
        const string CONDITIONS_ENDPOINT = "currentconditions/v1/{0}?apikey={1}";
        const string FORECAST_ENDPOINT = "forecasts/v1/daily/5day/{0}?apikey={1}&language=pt-br&details=false&metric=true";

        public static async Task<ForecastConditions> GetForecast()
        {
            ForecastConditions forecast = new ForecastConditions();

            string url = BASE_URL + string.Format(FORECAST_ENDPOINT, MEDIANEIRA_KEY, ACCUWEATHER_API_KEY);

            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync(url);
                string responseJson = await response.Content.ReadAsStringAsync();
                forecast = JsonConvert.DeserializeObject<ForecastConditions>(responseJson);
            }

            return forecast;

        }

    }
}
