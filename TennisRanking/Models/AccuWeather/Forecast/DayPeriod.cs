using System;
using System.Collections.Generic;
using System.Text;

namespace TennisRanking.Models.AccuWeather.Forecast
{
    public class DayPeriod
    {
        public int Icon { get; set; }
        public string IconPhrase { get; set; }
        public bool HasPrecipitation { get; set; }
        public string PrecipicitationType { get; set; }
        public string PrecipicatitionIntensity { get; set; }
    }
}
