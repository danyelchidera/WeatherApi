using Entities;
using Utilities.Dtos;

namespace PresentationServices.Contracts
{
    public interface ICityService
    {
        Task<ExecutionResponse<CityDto>> GetCityForecast(string city, bool trackChanges);
        Task<ExecutionResponse<CityDto>> StopWeatherUpdateForCity(Guid id, bool trackchanges);
    }
}