using Newtonsoft.Json;

namespace WeatherNotifierBot.Domain.Forecast
{
    public class Coordinates
    {
        [JsonProperty("lat")]
        public decimal Lat { get; set; }

        [JsonProperty("lon")]
        public decimal Lon { get; set; }
    }
}
