using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IRepositoryManager
    {
        ILocationDataRepository Location { get; }
        IWeatherDataRepository WeatherData { get; }
        Task SaveAsync();
    }


}
