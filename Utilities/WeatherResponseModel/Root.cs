namespace Utilities.WeatherResponseModel
{
    public class Root
    {
#nullable disable
        public string Cod { get; set; }
        public int Message { get; set; }
        public int Cnt { get; set; }
        public List<ForecastModel> List { get; set; }
        public ReponseCity City { get; set; }
    }
}



