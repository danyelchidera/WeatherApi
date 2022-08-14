using Entities;

namespace Contracts
{
    public interface IWeatherDataRepository
    {
        void DeleteMultiple(IEnumerable<WeatherData> weatherDatas);
    }
}