using AutoMapper;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using SmartHome.Controller;
using SmartHome.WebApp.Hubs;
using SmartHome.WebApp.Models.State;
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
        private readonly IMapper _mapper;
        private readonly IHubContext<StateHub> _stateHub;
        private ILogger<StateMonitorBackgroundService> _logger;
        private readonly int _delayMilliseconds;

        public StateMonitorBackgroundService(IStateMonitor monitor, IMapper mapper, IHubContext<StateHub> stateHub, ILogger<StateMonitorBackgroundService> logger)
        {
            _monitor = monitor;
            _mapper = mapper;
            _stateHub = stateHub;
            _logger = logger;
            _delayMilliseconds = 2000;
        }
        
        
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Сервис мониторинга запущен");
            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    var state = _mapper.Map<StateModel>(_monitor.GetSummary());
                    await _stateHub.Clients.All.SendAsync("receiveStateData", state);
                    await Task.Delay(_delayMilliseconds, stoppingToken);
                }
                catch(Exception e)
                {
                    _logger.LogError(e, "Сбой в работе сервиса мониторинга");
                }
            }
            _logger.LogInformation("Сервис мониторинга остановлен");
        }
    }
}
