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

        //checks first for data for a particular city in the database, if its not there, it gets it and saves it to db.
        //this way the user(s) can store weather data for cities they want to keep track of and have those data refresh
        //every 15mins
        public async Task<ExecutionResponse<LocationDataDto>> GetLocationForecast(string city, bool trackChanges)
        {
           var locationData = await _repository.Location.GetLocationAsync(city, trackChanges);

            if (locationData == null)
                locationData = await _dataService.GetWeatherDataForLocationAsync(city);
            
            var locationDataDto = _mapper.Map<LocationDataDto>(locationData);

            return new ExecutionResponse<LocationDataDto>()
            {
                Status = true,
                StatusCode = 200,
                Data = locationDataDto
            };
        }
    }
}
