using Contracts;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class BackgroundTask: BackgroundService
    {
        private readonly IServiceProvider Services;
        private readonly ILoggerManager _logger;

        public BackgroundTask(IServiceProvider services, ILoggerManager logger)
        {
            Services = services;
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInfo("Background task has started");
            await DoWork(stoppingToken);
        }

        private async Task DoWork(CancellationToken stoppingToken)
        {
            using (var scope = Services.CreateScope())
            {
                var dataRefresher = scope.ServiceProvider.GetRequiredService<IDataRefresher>();
                await dataRefresher.DoWork(stoppingToken);
            }
        }
    }
}
