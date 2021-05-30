using System;
using System.Collections.Generic;
using System.Text;

namespace TennisRanking.Models.AccuWeather.Forecast
{
    public class TemperatureMinMax
    {
        public int Value { get; set; }
        public string Unit { get; set; }
        public int UnitType { get; set; }
    }
}
