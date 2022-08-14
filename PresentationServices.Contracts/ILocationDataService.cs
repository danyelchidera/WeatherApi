using Entities;
using Utilities.Dtos;

namespace PresentationServices.Contracts
{
    public interface ILocationDataService
    {
        Task<LocationDataDto> GetLocationForecast(string city, bool trackChanges);
        Task Refresh();
    }
}