using System;
using System.Collections.Generic;
using System.Text;

namespace TennisRanking.Models.AccuWeather.Forecast
{
    public class ForecastConditions
    {
        public Headline Headline { get; set; }
        public IEnumerable<DailyForecast> DailyForecast { get; set; }
    }
}
