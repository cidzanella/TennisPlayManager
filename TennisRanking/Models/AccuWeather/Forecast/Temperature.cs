using System;
using System.Collections.Generic;
using System.Text;

namespace TennisRanking.Models.AccuWeather.Forecast
{
    public class Temperature
    {
        public TemperatureMinMax Minimum { get; set; }
        public TemperatureMinMax Maximum { get; set; }
    }
}
