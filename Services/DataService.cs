using AutoMapper;
using Contracts;
using Entities;
using Entities.Exceptions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
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
        private readonly ConfigOptions _configOptions;

        public DataService(IHttpService httpService, IConfiguration config, 
            IRepositoryManager repository, IMapper mapper, IOptionsSnapshot<ConfigOptions> configOptions)
        {
            _httpService = httpService;
            _config = config;
            _repository = repository;
            _mapper = mapper;
            _configOptions = configOptions.Value;
        }

        //gets forecast for 5 days at 3 hours interval for a particular location and saves to db 
        public async Task<LocationData> GetWeatherDataForLocationAsync(string city)
        {
            var rootLocation = await RequestForLocationData(city);
            var location = _mapper.Map<LocationData>(rootLocation);

            _repository.Location.CreateLocationData(location);
            await _repository.SaveAsync();
            return location;
        }

        //refreshes data for every city(location) that's been kept track of
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
                Url = _configOptions.Url,
                ApiKey = _configOptions.ApiKey,
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
