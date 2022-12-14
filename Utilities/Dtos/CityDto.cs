using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities.Dtos
{
    public class CityDto
    {
#nullable disable
        public Guid Id { get; set; }
        public string CityName { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string Country { get; set; }
        public int Population { get; set; }
        public int TimeZone { get; set; }
        public int Sunrise { get; set; }
        public int Sunset { get; set; }
        public ICollection<WeatherForecastDto> WeatherForecast { get; set; }

    }
}
