using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Utilities;
using Utilities.WeatherResponseModel;

namespace Contracts
{
    public interface IHttpService
    {
        Task<(bool status, string result, HttpStatusCode statusCode)> SendGetAsync(WeatherDataRequestParams request);
    }
}
