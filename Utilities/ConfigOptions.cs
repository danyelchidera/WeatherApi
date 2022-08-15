using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities
{
    public class ConfigOptions
    {
        public const string Options = "OpenWeather";
        public string Url { get; set; }
        public string ApiKey { get; set; }
    }
}
