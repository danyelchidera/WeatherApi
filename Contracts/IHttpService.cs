using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities;
using Utilities.WeatherResponseModel;

namespace Contracts
{
    public interface IHttpService
    {
        Task<T> SendGetAsync<T>(RequestParameters request);
    }
}
