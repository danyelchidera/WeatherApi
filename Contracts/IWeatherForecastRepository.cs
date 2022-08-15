using Entities;

namespace Contracts
{
    public interface IWeatherForecastRepository
    {
        void DeleteMultiple(IEnumerable<WeatherForecast> weatherDatas);
    }
}