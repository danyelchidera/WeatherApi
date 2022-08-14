using Newtonsoft.Json;

namespace Utilities.WeatherResponseModel
{
    public class Rain
    {
        [JsonProperty(PropertyName = "_3h")]
        public double RainValue3h { get; set; }
    }
}



