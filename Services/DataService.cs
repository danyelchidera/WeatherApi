using AutoMapper;
using Contracts;
using Entities;
using Microsoft.Extensions.Configuration;
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
            RequestParameters requestParams = new()
            {
                Url = _config["OpenWeather:Url"],
                ApiKey = _config["OpenWeather:ApiKey"],
                City = city
            };

            var rootLocation = await _httpService.SendGetAsync<Root>(requestParams);
            var location = _mapper.Map<LocationData>(rootLocation);

            _repository.Location.CreateLocation(location);
            await _repository.SaveAsync();
            return location;
        }

        public Task RefreshDbData()
        {
            throw new NotImplementedException();
        }
    }
}
