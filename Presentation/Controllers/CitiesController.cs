using Entities.ErrorModels;
using Microsoft.AspNetCore.Mvc;
using PresentationServices.Contracts;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                return StatusCode(result.StatusCode, new ErrorDetails(){StatusCode = result.StatusCode, Message = result.Message});
            return Ok(result.Data);
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
