using Newtonsoft.Json;

namespace WeatherNotifierBot.Domain.Forecast
{
    public class Wind
    {
        [JsonProperty("speed")]
        public long Speed { get; set; }

        [JsonProperty("deg")]
        public long Deg { get; set; }
    }
}
