using Contracts;
using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class LocationDataRepository : RepositoryBase<LocationData>, ILocationDataRepository
    {
        public LocationDataRepository(RepositoryContext repositoryContext)
        : base(repositoryContext)
        {
        }

        public void CreateLocation(LocationData location) => Create(location);

        public async Task<LocationData> GetLocationAsync(string cityName, bool trackChanges) =>
            await FindByCondition(x => x.CityName.ToLower() == cityName.Trim().ToLower(), trackChanges)
                .FirstOrDefaultAsync();
    }
}
