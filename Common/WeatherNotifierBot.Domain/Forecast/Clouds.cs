using Newtonsoft.Json;

namespace WeatherNotifierBot.Domain.Forecast
{
    public class Clouds
    {
        [JsonProperty("all")]
        public long All { get; set; }
    }
}
