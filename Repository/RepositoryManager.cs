using Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public sealed class RepositoryManager : IRepositoryManager
    {
        private readonly RepositoryContext _repositoryContext;
        private readonly Lazy<ICityRepository> _cityRepository;
        private readonly Lazy<IWeatherForecastRepository> _weatherForecastRepository;

        public RepositoryManager(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
            _cityRepository = new Lazy<ICityRepository>(() => new CityRepository(repositoryContext));
            _weatherForecastRepository = new Lazy<IWeatherForecastRepository>(() => new WeatherForecastRepository(repositoryContext));
        }
        public ICityRepository City => _cityRepository.Value;
        public IWeatherForecastRepository WeatherForecast => _weatherForecastRepository.Value;
        public Task SaveAsync() => _repositoryContext.SaveChangesAsync();
    }

}
