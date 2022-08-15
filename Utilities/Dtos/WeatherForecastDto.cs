using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities.Dtos
{
    public class WeatherForecastDto
    {
        public Guid Id { get; set; }
        public double TempFeelsLike { get; set; }
        public double Temp { get; set; }
        public double TempMax { get; set; }
        public double TempMin { get; set; }
        public int Pressure { get; set; }
        public int SeaLevel { get; set; }
        public int GroundLevel { get; set; }
        public int Humidity { get; set; }
        public double TempKf { get; set; }
        public double WindSpeed { get; set; }
        public int WindDeg { get; set; }
        public double WindGust { get; set; }
        public int Visibility { get; set; }
        public DateTime Date { get; set; }
        public string WeatherMain { get; set; }
        public string WeatherDescription { get; set; }
        public double RainValue3h { get; set; }
        public Guid CityId { get; set; }
        
    }
}
