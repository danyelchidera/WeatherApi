using Newtonsoft.Json;

namespace Utilities.WeatherResponseModel
{
    public class Main
    {
        public double Temp { get; set; }
        [JsonProperty(PropertyName = "feels_Like")]
        public double FeelsLike { get; set; }
        [JsonProperty(PropertyName = "temp_min")]
        public double TempMin { get; set; }
        [JsonProperty(PropertyName = "Temp_max")]
        public double TempMax { get; set; }
        public int Pressure { get; set; }
        [JsonProperty(PropertyName = "sea_level")]
        public int SeaLevel { get; set; }
        [JsonProperty(PropertyName = "grnd_level")]
        public int GroundLevel { get; set; }
        public int Humidity { get; set; }
       
        public double TempKf { get; set; }
    }
}



