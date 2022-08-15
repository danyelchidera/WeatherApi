using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IDataService
    {
        Task<City> GetWeatherDataForCityAsync(string city);
        Task RefreshDbData();
    }
}
