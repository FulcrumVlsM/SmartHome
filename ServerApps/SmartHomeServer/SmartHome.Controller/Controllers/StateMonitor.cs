﻿using Microsoft.Extensions.Logging;
using SmartHome.Common.Enums;
using SmartHome.Controller.Models;
using SmartHome.Data;
using SmartHome.Data.Models;
using SmartHome.Data.Store;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmartHome.Controller.Controllers
{
    public class StateMonitor : IStateMonitor
    {
        private readonly IRepository<NumericSensor> _numericSensorRepository;
        private readonly IRepository<BoolActionDevice> _boolActionDeviceRepository;
        private readonly IHistoryRepository<NumericSensorHistoryItem> _numericSensorHistoryRepository;
        private readonly IDeviceController _controller;
        private readonly ILogger<StateMonitor> _logger;

        public StateMonitor(IStoreFactory storeFactory, IDeviceController controller, ILogger<StateMonitor> logger)
        {
            _numericSensorRepository = storeFactory.ControllerDataStore.NumericSensors;
            _boolActionDeviceRepository = storeFactory.ControllerDataStore.BoolActionDevices;
            _numericSensorHistoryRepository = storeFactory.HistoryStore.NumericSensorHistory;
            _controller = controller;
            _logger = logger;
        }
        
        
        public Summary GetSummary()
        {
            _logger.LogTrace("Вызван GetSummary()");
            
            var now = DateTime.Now;
            var activeTemperatureSensors = _numericSensorRepository.Where(sensor => sensor.ActivityMode && sensor.Category == DeviceCategory.Temperature);
            var activeHimiditySensors = _numericSensorRepository.Where(sensor => sensor.ActivityMode && sensor.Category == DeviceCategory.Humidity);
            var activeDioxideSensors = _numericSensorRepository.Where(sensor => sensor.ActivityMode && sensor.Category == DeviceCategory.Dioxide);

            var deviceNames = _controller.GetActiveBoolActionDeviceNames();
            var activeDevices = _boolActionDeviceRepository.Where(device => deviceNames.Contains(device.SysName));
            var summary = new Summary()
            {
                TemperatureSummary = new SensorSummary { Sensors = activeTemperatureSensors },
                HimiditySummary = new SensorSummary { Sensors = activeHimiditySensors },
                DioxideSummary = new SensorSummary { Sensors = activeDioxideSensors },
                ActiveDevices = activeDevices
            };
            summary.TemperatureSummary.History = _numericSensorHistoryRepository
                .Where(item => activeTemperatureSensors.Any(sensor => sensor.SysName == item.SysName) && item.CreateDate >= now.AddDays(-1));
            summary.HimiditySummary.History = _numericSensorHistoryRepository
                .Where(item => activeHimiditySensors.Any(sensor => sensor.SysName == item.SysName) && item.CreateDate >= now.AddDays(-1));
            summary.DioxideSummary.History = _numericSensorHistoryRepository
                .Where(item => activeDioxideSensors.Any(sensor => sensor.SysName == item.SysName) && item.CreateDate >= now.AddDays(-1));

            return summary;
        }
    }
}
