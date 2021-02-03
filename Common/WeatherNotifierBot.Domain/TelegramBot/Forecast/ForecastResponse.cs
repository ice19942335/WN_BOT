using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherNotifierBot.Domain.TelegramBot.Forecast
{
    public class ForecastResponse
    {
        public string Cod { get; set; }
        public string Message { get; set; }
        public long Cnt { get; set; }
        public List<Forecast> ForecastList { get; set; }
        public City City { get; set; }
    }

    public class Forecast
    {
        public long Dt { get; set; }
        public Main Main { get; set; }
        public List<Weather> WeatherList { get; set; }
        public Clouds Clouds { get; set; }
        public Wind Wind { get; set; }
        public long Visibility { get; set; }
        public long Pop { get; set; }
        //Should be one more object named Snow
        public Sys Sys { get; set; }
        public string DateTimeText { get; set; }
    }

    public class Main
    {
        public long Temp { get; set; }
        public long FeelsLike { get; set; }
        public long TempMin { get; set; }
        public long TempMax { get; set; }
        public long Pressure { get; set; }
        public long SeaLevel { get; set; }
        public long GrndLevel { get; set; }
        public long Humidity { get; set; }
        public long TempKf { get; set; }
    }

    public class Weather
    {
        public long id { get; set; }
        public string Main { get; set; }
        public string Description { get; set; }
        public string Icon { get; set; }
    }

    public class Clouds
    {
        public long All { get; set; }
    }

    public class Wind
    {
        public long Speed { get; set; }
        public long Deg { get; set; }
    }

    public class Sys
    {
        public string Pod { get; set; }
    }

    public class City
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public Coordinates Coordinates { get; set; }
        public string Country { get; set; }
        public long Population { get; set; }
        public long Timezone { get; set; }
        public long Sunrise { get; set; }
        public long Sunset { get; set; }
    }

    public class Coordinates
    {
        public decimal Lat { get; set; }
        public decimal Lon { get; set; }
    }
}
