using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface ILocationDataRepository
    {
        void CreateLocation(LocationData location);
        Task<LocationData> GetLocationAsync(string cityName, bool trackChanges);
    }
}
