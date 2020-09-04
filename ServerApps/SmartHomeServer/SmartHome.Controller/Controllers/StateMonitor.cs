using Microsoft.Extensions.Logging;
using SmartHome.Common.Enums;
using SmartHome.Controller.Entities;
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
        private readonly IDataStore _dataStore;
        private readonly IHistoryStore _historyDataStore;
        private readonly IDeviceController _controller;
        private readonly ILogger<StateMonitor> _logger;

        public StateMonitor(IStoreFactory storeFactory, IDeviceController controller, ILogger<StateMonitor> logger)
        {
            _dataStore = storeFactory.ConfigurationDataStore;
            _historyDataStore = storeFactory.HistoryStore;
            _controller = controller;
            _logger = logger;
        }
        
        
        public Summary GetSummary()
        {
            _logger.LogTrace("Вызван StateMonitor.GetSummary()");
            var numericSensorRepository = _dataStore.NumericSensors;
            var boolActionDeviceRepository = _dataStore.BoolActionDevices;
            var numericSensorHistoryRepository = _historyDataStore.NumericSensorHistory;

            var yesterday = DateTime.Now.AddDays(-1);
            var activeTemperatureSensors = numericSensorRepository.Where(sensor => sensor.ActivityMode && sensor.Category == DeviceCategory.Temperature);
            var activeHimiditySensors = numericSensorRepository.Where(sensor => sensor.ActivityMode && sensor.Category == DeviceCategory.Humidity);
            var activeDioxideSensors = numericSensorRepository.Where(sensor => sensor.ActivityMode && sensor.Category == DeviceCategory.Dioxide);

            var deviceNames = _controller.GetActiveBoolActionDeviceNames();
            var activeDevices = boolActionDeviceRepository.Where(device => deviceNames.Contains(device.SysName));
            
            var summary = new Summary()
            {
                TemperatureSummary = new SensorSummary { Sensors = activeTemperatureSensors },
                HimiditySummary = new SensorSummary { Sensors = activeHimiditySensors },
                DioxideSummary = new SensorSummary { Sensors = activeDioxideSensors },
                ActiveDevices = activeDevices
            };

            //TODO: убрать обработку на клиенте
            var sensorHistory = numericSensorHistoryRepository.Where(item => item.CreateDate >= yesterday).ToList();

            summary.TemperatureSummary.History = GetGroupedHistory(sensorHistory.Where(item => activeTemperatureSensors.Any(sensor => sensor.SysName == item.SysName)));
            summary.HimiditySummary.History = GetGroupedHistory(sensorHistory.Where(item => activeHimiditySensors.Any(sensor => sensor.SysName == item.SysName)));
            summary.DioxideSummary.History = GetGroupedHistory(sensorHistory.Where(item => activeDioxideSensors.Any(sensor => sensor.SysName == item.SysName)));

            return summary;
        }



        /// <summary>
        /// Группирует данные по часам и находит для них среднее значение
        /// </summary>
        /// <param name="historyItems"></param>
        /// <returns></returns>
        private IEnumerable<NumericSensorGroupedHistoryItem> GetGroupedHistory(IEnumerable<NumericSensorHistoryItem> historyItems)
        {
            return historyItems
                .Select(item =>
            {
                var date = item.CreateDate.Date;
                var hour = item.CreateDate.Hour;
                return new { Date = date.AddHours(hour), item.ID, item.SysName, item.Value };
            })
                .GroupBy(item => item.Date)
                .Select(item => new NumericSensorGroupedHistoryItem { DateTime = item.Key, Value = item.Average(groupedItem => groupedItem.Value) });
        }
    }
}
