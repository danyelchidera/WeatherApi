using Contracts;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class WeatherDataRepository : RepositoryBase<WeatherData>, IWeatherDataRepository
    {
        public WeatherDataRepository(RepositoryContext repositoryContext)
        : base(repositoryContext)
        {
        }

        public void DeleteMultiple(IEnumerable<WeatherData> weatherDatas) => DeleteRange(weatherDatas);
    }
    
}
