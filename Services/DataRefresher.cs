using Contracts;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class DataRefresher : IDataRefresher
    {
        private readonly IServiceProvider Services;
       
        public DataRefresher(IServiceProvider services)
        {
            Services = services;
        }
        public async Task DoWork(CancellationToken stoppingToken)
        {
            while(!stoppingToken.IsCancellationRequested)
            {
                using (var scope = Services.CreateScope())
                {
                    var dataRefresher = scope.ServiceProvider.GetRequiredService<IDataService>();
                    await dataRefresher.RefreshDbData();
                }
                await Task.Delay(1000 * 60 * 15);
            }
        }
    }
}
