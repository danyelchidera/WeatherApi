﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IRepositoryManager
    {
        ILocationRepository Location { get; }
        IWeatherDataRepository WeatherData { get; }
        Task SaveAsync();
    }


}