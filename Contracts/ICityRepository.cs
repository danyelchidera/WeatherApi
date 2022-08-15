using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities.Pagination;

namespace Contracts
{
    public interface ICityRepository
    {
        void CreateForecastForCity(City city);
        Task<City?> GetCityForecastAsync(string cityName, bool trackChanges);
        Task<City?> GetCityByIdAsync(Guid id, bool trackChanges);
        PagedList<City> GetPagedCityForecastAsync(PagingParameters parameters, bool trackChanges);
        Task<IEnumerable<City>> GetAllCityForecastAsync(bool trackChanges);
        void RemoveCity(City city);
    }
}
