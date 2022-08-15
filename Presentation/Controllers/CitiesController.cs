using Entities.ErrorModels;
using Microsoft.AspNetCore.Mvc;
using PresentationServices.Contracts;
using System.Text.Json;
using Utilities.Pagination;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class CitiesController: ControllerBase
    {
        private readonly ICityService _cityService;

        public CitiesController(ICityService cityService)
        {
            _cityService = cityService;
        }

        [HttpGet("{city}")]
        public async Task<IActionResult> GetForecastForCity(string city)
        {
            var result = await _cityService.GetCityForecast(city, false);
            if(!result.Status)
                return StatusCode(result.StatusCode, 
                    new ErrorDetails(){StatusCode = result.StatusCode, Message = result.Message});
            return Ok(result.Data);
        }

        [HttpGet]
        public IActionResult GetCities([FromQuery] PagingParameters parameters)
        {
            var result = _cityService.GetCitiesForecast(parameters, false);

            if (!result.response.Status)
                return StatusCode(result.response.StatusCode, 
                    new ErrorDetails() { StatusCode = result.response.StatusCode, Message = result.response.Message });

            Response.Headers.Add("X-Pagination",JsonSerializer.Serialize(result.metaData));

            return Ok(result.response.Data);
        }

        [HttpDelete("stopUpdate/{cityId}")]
        public async Task<IActionResult> StopCityUpdate(Guid cityId)
        {
            var result = await _cityService.StopWeatherUpdateForCity(cityId, false);
            if (!result.Status)
                return StatusCode(result.StatusCode, new ErrorDetails() { StatusCode = result.StatusCode, Message = result.Message });
            return NoContent();
        }
    }
}
