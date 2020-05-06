using Microsoft.Extensions.Hosting;
using SmartHome.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SmartHome.WebApp.Services
{
    public class DeviceControllerBackgroundService : BackgroundService
    {
        private readonly IDeviceController _controller;
        private readonly int _delayMilisecond;

        public DeviceControllerBackgroundService(IDeviceController controller)
        {
            _controller = controller;
            _delayMilisecond = 500;
        }
        
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                await _controller.Refresh();
                await Task.Delay(_delayMilisecond, stoppingToken);
            }
        }
    }
}
