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
        private readonly Lazy<ILocationDataRepository> _locationRepository;
        private readonly Lazy<IWeatherDataRepository> _weatherDataRepository;
        public RepositoryManager(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
            _locationRepository = new Lazy<ILocationDataRepository>(() => new LocationDataRepository(repositoryContext));
            _weatherDataRepository = new Lazy<IWeatherDataRepository>(() => new WeatherDataRepository(repositoryContext));
        }
        public ILocationDataRepository Location => _locationRepository.Value;
        public IWeatherDataRepository WeatherData => _weatherDataRepository.Value;
        public Task SaveAsync() => _repositoryContext.SaveChangesAsync();
    }

}
