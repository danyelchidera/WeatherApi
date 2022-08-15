using Contracts;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class WeatherForecastRepository : RepositoryBase<WeatherForecast>, IWeatherForecastRepository
    {
        public WeatherForecastRepository(RepositoryContext repositoryContext)
        : base(repositoryContext)
        {
        }

        public void DeleteMultiple(IEnumerable<WeatherForecast> weatherDatas) => DeleteRange(weatherDatas);
    }
    
}
