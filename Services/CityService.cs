using AutoMapper;
using Contracts;
using PresentationServices.Contracts;
using Utilities.Dtos;
using Utilities.Pagination;

namespace Services
{
    public class CityService : ICityService
    {
        private readonly IRepositoryManager _repository;
        private readonly IDataService _dataService;
        private readonly IMapper _mapper;

        public CityService(IRepositoryManager repository, IDataService dataService, IMapper mapper)
        {
            _repository = repository;
            _dataService = dataService;
            _mapper = mapper;
        }

        public (ExecutionResponse<IEnumerable<CityDto>> response, MetaData metaData) GetCitiesForecast(PagingParameters parameters, 
            bool trackChanges)
        {
            var pagedList = _repository.City.GetPagedCityForecastAsync(parameters, trackChanges);
            var citiesDto = _mapper.Map<IEnumerable<CityDto>>(pagedList);

            var metaData = pagedList.MetaData;
            var executionResponse = new ExecutionResponse<IEnumerable<CityDto>>()
            {
                Status = true,
                StatusCode = 200,
                Data = citiesDto
            };

            return (response: executionResponse, metaData: metaData);
        }
        

        public async Task<ExecutionResponse<CityDto>> GetCityForecast(string city, bool trackChanges)
        {
           var cityForecast = await _repository.City.GetCityForecastAsync(city, trackChanges);

            if (cityForecast == null)
                cityForecast = await _dataService.GetWeatherDataForCityAsync(city);
            
            var cityForecastDto = _mapper.Map<CityDto>(cityForecast);

            return new ExecutionResponse<CityDto>()
            {
                Status = true,
                StatusCode = 200,
                Data = cityForecastDto
            };
        }

        public async Task<ExecutionResponse<CityDto>> StopWeatherUpdateForCity(Guid id, bool trackChanges)
        {
            var city = await _repository.City.GetCityByIdAsync(id, trackChanges);
            if (city == null)
                return new ExecutionResponse<CityDto>()
                {
                    Status = false,
                    StatusCode = 404,
                    Message = $"There is currently no city with id {id} beign tracked"
                };
            _repository.City.RemoveCity(city);
            await _repository.SaveAsync();

            return new ExecutionResponse<CityDto>()
            {
                Status = true,
                StatusCode = 204,
            };

        }

        
    }
}
