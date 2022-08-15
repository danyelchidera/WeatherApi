using AutoMapper;
using Contracts;
using Entities;
using Entities.Exceptions;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Utilities;
using Utilities.WeatherResponseModel;

namespace Services
{
    public class DataService : IDataService
    {
        private readonly IHttpService _httpService;
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;
        private readonly ConfigOptions _configOptions;

        public DataService(IHttpService httpService, 
            IRepositoryManager repository, IMapper mapper, IOptionsSnapshot<ConfigOptions> configOptions)
        {
            _httpService = httpService;
            _repository = repository;
            _mapper = mapper;
            _configOptions = configOptions.Value;
        }

        public async Task<City> GetWeatherDataForCityAsync(string city)
        {
            var rootCity = await RequestForCityData(city);
            var cityForecast = _mapper.Map<City>(rootCity);

            _repository.City.CreateForecastForCity(cityForecast);
            await _repository.SaveAsync();
            return cityForecast;
        }

        public async Task RefreshDbData()
        {
            var cities = await _repository.City.GetAllCityForecastAsync(true);
            foreach(var city in cities)
            {
                var newCityForecast = await RequestForCityData(city.CityName);
                _mapper.Map(newCityForecast, city);
            }
            await _repository.SaveAsync();
        }

        private async Task<Root?> RequestForCityData(string city)
        {
            WeatherDataRequestParams requestParams = new()
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
