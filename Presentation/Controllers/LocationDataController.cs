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
    public class LocationDataController: ControllerBase
    {
        private readonly ILocationDataService _locationDataService;

        public LocationDataController(ILocationDataService locationDataService)
        {
            _locationDataService = locationDataService;
        }

        [HttpGet("{city}")]
        public async Task<IActionResult> GetForecastForCity(string city)
        {
            var result = await _locationDataService.GetLocationForecast(city, false);
            if(!result.Status)
                return StatusCode(result.StatusCode, new {Status = result.Status, Message = result.Message});
            return Ok(result.Data);
        }
    }
}
