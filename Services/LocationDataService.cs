using AutoMapper;
using Contracts;
using Entities;
using PresentationServices.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities.Dtos;

namespace Services
{
    public class LocationDataService : ILocationDataService
    {
        private readonly IRepositoryManager _repository;
        private readonly IDataService _dataService;
        private readonly IMapper _mapper;

        public LocationDataService(IRepositoryManager repository, IDataService dataService, IMapper mapper)
        {
            _repository = repository;
            _dataService = dataService;
            _mapper = mapper;
        }

        public async Task Refresh()
        {
            await _dataService.RefreshDbData();
        }

        public async Task<LocationDataDto> GetLocationForecast(string city, bool trackChanges)
        {
           var locationData = await _repository.Location.GetLocationAsync(city, trackChanges);

            if (locationData == null)
                locationData = await _dataService.GetWeatherDataForLocationAsync(city);
            
            var locationDataDto = _mapper.Map<LocationDataDto>(locationData);

            return locationDataDto;
        }
    }
}
