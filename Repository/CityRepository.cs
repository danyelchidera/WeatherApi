using Contracts;
using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities.Pagination;

namespace Repository
{
    public class CityRepository : RepositoryBase<City>, ICityRepository
    {
        public CityRepository(RepositoryContext repositoryContext)
        : base(repositoryContext)
        {
        }

        public void CreateForecastForCity(City city) => Create(city);

        public async Task<IEnumerable<City>> GetAllCityForecastAsync(bool trackChanges) =>
            await FindAll(trackChanges)
            .Include(e => e.WeatherForecast)
            .ToListAsync();

        public async Task<City?> GetCityByIdAsync(Guid id, bool trackChanges) => 
            await FindByCondition(x => x.Id.Equals(id),trackChanges)
            .FirstOrDefaultAsync();

        public async Task<City?> GetCityForecastAsync(string cityName, bool trackChanges) =>
            await FindByCondition(x => x.CityName.ToLower() == cityName.Trim().ToLower(), trackChanges)
            .Include(x => x.WeatherForecast)
            .FirstOrDefaultAsync();

        public PagedList<City> GetPagedCityForecastAsync(PagingParameters parameters, bool trackChanges)
        {
            var cities = FindAll(trackChanges)
            .Include(e => e.WeatherForecast)
            .OrderBy(e => e.CityName);

            return PagedList<City>.ToPagedList(cities, parameters.PageNumber, parameters.PageSize);
        }

        public void RemoveCity(City city) => Delete(city);
    }
}
