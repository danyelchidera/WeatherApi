using AutoMapper;
using Contracts;
using Entities;
using Entities.Exceptions;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities;
using Utilities.WeatherResponseModel;

namespace Services
{
    public class DataService : IDataService
    {
        private readonly IHttpService _httpService;
        private readonly IConfiguration _config;
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;

        public DataService(IHttpService httpService, IConfiguration config, IRepositoryManager repository, IMapper mapper)
        {
            _httpService = httpService;
            _config = config;
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<LocationData> GetWeatherDataForLocationAsync(string city)
        {
            var rootLocation = await RequestForLocationData(city);
            var location = _mapper.Map<LocationData>(rootLocation);

            _repository.Location.CreateLocation(location);
            await _repository.SaveAsync();
            return location;
        }

        public async Task RefreshDbData()
        {
            var locationDatas = await _repository.Location.GetAllLocationsAsync(true);
            foreach(var locationData in locationDatas)
            {
                var newLocationData = await RequestForLocationData(locationData.CityName);
                _mapper.Map(newLocationData, locationData);
            }
            await _repository.SaveAsync();
        }

        private async Task<Root?> RequestForLocationData(string city)
        {
            RequestParameters requestParams = new()
            {
                Url = _config["OpenWeather:Url"],
                ApiKey = _config["OpenWeather:ApiKey"],
                City = city
            };
            var response = await _httpService.SendGetAsync(requestParams);
            
            if (!response.status)
            {
                var errorResponse = JsonConvert.DeserializeObject<ErrorResponse>(response.result);
                var exception = new OpenWeatherResponseException(errorResponse?.Message ?? "An error occured");
                exception.Data["StatusCode"] = (int) response.statusCode;
                throw exception;
            }
            return JsonConvert.DeserializeObject<Root>(response.result);
        }
    }
}
