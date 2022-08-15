using Entities;
using Utilities.Dtos;

namespace PresentationServices.Contracts
{
    public interface ILocationDataService
    {
        Task<ExecutionResponse<LocationDataDto>> GetLocationForecast(string city, bool trackChanges);
    }
}