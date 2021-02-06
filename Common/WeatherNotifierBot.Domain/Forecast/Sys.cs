using Newtonsoft.Json;

namespace WeatherNotifierBot.Domain.Forecast
{
    public class Sys
    {
        [JsonProperty("pod")]
        public string Pod { get; set; }
    }
}
