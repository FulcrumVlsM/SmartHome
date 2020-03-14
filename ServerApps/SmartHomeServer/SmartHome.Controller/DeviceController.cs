using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SmartHome.Controller.Values;
using SmartHome.Data.Models;
using SmartHome.Data.Store;
using SmartHome.Controller.Comparators;
using SmartHome.Common.Enums;
using SmartHome.Controller.Entities;
using SmartHome.Data;

namespace SmartHome.Controller
{
    public sealed class DeviceController : IDeviceController
    {        
        private readonly Dictionary<string, BoolActionDeviceEntity> _boolActionDeviceEntities;

        private readonly IRepository<BoolActionDevice> _boolActionDeviceRepository;
        private readonly IRepository<BoolSensor> _boolSensorRepository;
        private readonly IRepository<NumericSensor> _numericSensorRepository;
        private readonly IRepository<EventDevice> _eventDeviceRepository;
        private readonly IRepository<Rule> _ruleRepository;

        private readonly IHistoryRepository<BoolActionDeviceHistoryItem> _boolActionDevicesHistoryRepository;
        private readonly IHistoryRepository<BoolSensorHistoryItem> _boolSensorHistoryRepository;
        private readonly IHistoryRepository<NumericSensorHistoryItem> _numericSensorHistoryRepository;
        private readonly IHistoryRepository<EventDeviceHistoryItem> _eventDeviceHistoryRepository;


        public DeviceController(IDataStore dataStore, IHistoryStore historyStore)
        {
            _boolActionDeviceRepository = dataStore.BoolActionDevices;
            _boolSensorRepository = dataStore.BoolSensors;
            _numericSensorRepository = dataStore.NumericSensors;
            _eventDeviceRepository = dataStore.EventDevices;
            _ruleRepository = dataStore.Rules;

            _boolActionDevicesHistoryRepository = historyStore.BoolActionDeviceHistory;
            _boolSensorHistoryRepository = historyStore.BoolSensorHistory;
            _numericSensorHistoryRepository = historyStore.NumericSensorHistory;
            _eventDeviceHistoryRepository = historyStore.EventDeviceHistory;

            _boolActionDeviceEntities = new Dictionary<string, BoolActionDeviceEntity>();
        }


        public bool PassValue(BoolSensorValue value)
        {
            var sensor = _boolSensorRepository[value.SensorName];
            if (sensor != null)
            {
                sensor.Value = value.Value;
                _boolSensorRepository.Save();
                _boolSensorHistoryRepository.Add(new BoolSensorHistoryItem()
                {
                    CreateDate = DateTime.Now,
                    SysName = sensor.SysName,
                    Value = sensor.Value
                });
                _boolSensorHistoryRepository.Save();
                return true;
            }
            else return false;
        }

        public bool PassValue(NumericSensorValue value)
        {
            var sensor = _numericSensorRepository[value.SensorName];
            if (sensor != null)
            {
                sensor.Value = value.Value;
                _numericSensorRepository.Save();

                _numericSensorHistoryRepository.Add(new NumericSensorHistoryItem()
                {
                    SysName = sensor.SysName,
                    CreateDate = DateTime.Now,
                    Value = value.Value
                });
                _numericSensorHistoryRepository.Save();
                return true;
            }
            else return false;
        }

        public bool ThrowEvent(DeviceEventWrapper deviceEvent)
        {
            var eventDevice = _eventDeviceRepository.FirstOrDefault(device => device.SysName == deviceEvent.SensorName);
            if (eventDevice != null)
            {
                var rules = _ruleRepository.Where(rule => rule.Rule2EventDevices.Any(r2ed => r2ed.Device.SysName == deviceEvent.SensorName));
                var boolActionDevices = eventDevice.BoolDeviceActions.Select(bdea => new { bdea.Device, bdea.TargetStateMode });

                if (CheckRules(rules))
                {
                    foreach(var device in boolActionDevices)
                    {
                        device.Device.ActivityMode = device.TargetStateMode;
                    }
                    _eventDeviceRepository.Save();
                }
                
                //записать в историю
                _eventDeviceHistoryRepository.Add(new EventDeviceHistoryItem()
                {
                    CreateDate = DateTime.Now,
                    SysName = deviceEvent.SensorName
                });
                _eventDeviceHistoryRepository.Save();
                return true;
            }
            else return false;
        }

        /// <summary>
        /// Регистрация обработчика для исполнительного устройства
        /// </summary>
        /// <param name="sysName">Системное имя устройства</param>
        /// <param name="eventHadler">Функция-обработчик</param>
        /// <returns></returns>
        public bool RegistryBoolActionDeviceHandler(string sysName, Action<bool> eventHadler)
        {
            if(!_boolActionDeviceEntities.TryGetValue(sysName, out BoolActionDeviceEntity entity))
            {
                var device = _boolActionDeviceRepository.FirstOrDefault(device => device.SysName == sysName);
                if (device == null) return false;
                
                entity = new BoolActionDeviceEntity(device, false);
                _boolActionDeviceEntities.Add(sysName, entity);
                entity.OnStateChanged += eventHadler;
            }
            else
            {
                entity.OnStateChanged += eventHadler;
            }

            return true;
        }

        public void Refresh()
        {
            foreach (var device in _boolActionDeviceRepository)
            {
                IEnumerable<int> rulesIDList = device.Rule2BoolActionDevices.Select(x => x.RuleID);
                var rules = _ruleRepository.Where(rule => rulesIDList.Contains(rule.ID));

                if(_boolActionDeviceEntities.TryGetValue(device.SysName, out BoolActionDeviceEntity entity) && entity.DeviceStateMode == DeviceStateMode.Auto)
                {
                    entity.Value = CheckRules(rules);
                }
            }
        }

        private bool CheckRules(IEnumerable<Rule> rules)
        {
            return rules
                    .Any(rule => rule.Nodes
                        .All(node =>
                        {
                            return node.BoolSensorConditions.All(condition => new BoolSensorConditionComparator(condition).IsRight())
                                    && node.NumericSensorConditions.All(condition => new NumericSensorConditionComparator(condition).IsRight())
                                    && node.TimeConditions.All(condition => new TimeConditionComparator(condition).IsRight())
                                    && node.UserConditions.All(condition => new UserConditionComparator(condition).IsRight());
                        }));
        }
    }
}
