using System;
using System.Collections.Generic;
using System.Text;

namespace TennisRanking.Models.AccuWeather.Forecast
{
    public class DailyForecast
    {
        public DateTime Date { get; set; }
        public int EpochDate { get; set; }
        public Temperature Temperature { get; set; }
        public DayPeriod Day { get; set; }
        public DayPeriod Night { get; set; }
        public IEnumerable<string> Sources { get; set; }
        public string MobileLink { get; set; }
        public string Link { get; set; }

    }
}
