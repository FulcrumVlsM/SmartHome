using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using SmartHome.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SmartHome.WebApp.Services
{
    public class StateMonitorBackgroundService : BackgroundService
    {
        private readonly IStateMonitor _monitor;
        private ILogger<StateMonitorBackgroundService> _logger;
        private readonly int _delayMilliseconds;

        public StateMonitorBackgroundService(IStateMonitor monitor, ILogger<StateMonitorBackgroundService> logger)
        {
            _monitor = monitor;
            _logger = logger;
            _delayMilliseconds = 2000;
        }
        
        
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Сервис мониторинга запущен");
            while (!stoppingToken.IsCancellationRequested)
            {
                var summary = _monitor.GetSummary();
                //далее следует оповещение подключенных к хабу клиентов
                await Task.Delay(_delayMilliseconds, stoppingToken);
            }
            _logger.LogInformation("Сервис мониторинга остановлен");
        }
    }
}
