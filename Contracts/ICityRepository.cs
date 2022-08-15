using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface ICityRepository
    {
        void CreateForecastForCity(City location);
        Task<City?> GetCityForecastAsync(string cityName, bool trackChanges);
        Task<City?> GetCityByIdAsync(Guid id, bool trackChanges);
        Task<IEnumerable<City>> GetAllCityForecastAsync(bool trackChanges);
        void RemoveCity(City city);
    }
}
