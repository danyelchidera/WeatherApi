using Entities;
using Utilities.Dtos;
using Utilities.Pagination;

namespace PresentationServices.Contracts
{
    public interface ICityService
    {
        Task<ExecutionResponse<CityDto>> GetCityForecast(string city, bool trackChanges);
        (ExecutionResponse<IEnumerable<CityDto>> response, MetaData metaData) GetCitiesForecast(PagingParameters parameters, bool trackChanges);
        Task<ExecutionResponse<CityDto>> StopWeatherUpdateForCity(Guid id, bool trackchanges);
    }
}