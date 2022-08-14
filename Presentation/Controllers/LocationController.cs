using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class LocationController: ControllerBase
    {
        public LocationController()
        {

        }

        [HttpGet("{city}")]
        public async Task<IActionResult> GetForecastForCity(string city)
        {

        }
    }
}
