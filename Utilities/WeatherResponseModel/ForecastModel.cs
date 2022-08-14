using Newtonsoft.Json;

namespace Utilities.WeatherResponseModel
{
    public class ForecastModel
    {
        public int Dt { get; set; }
        public Main Main { get; set; }
        public List<Weather> Weather { get; set; }
        public Clouds Clouds { get; set; }
        public Wind Wind { get; set; }
        public int Visibility { get; set; }
        public double Pop { get; set; }
        public Sys Sys { get; set; }
        [JsonProperty(PropertyName = "dt_txt")]
        public string DateText { get; set; }
        public Rain Rain { get; set; }
    }
}



