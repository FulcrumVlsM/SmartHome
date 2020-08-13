using System;
using System.Collections.Generic;
using System.Linq;
using SmartHome.Controller.Values;
using SmartHome.Data.Models;
using SmartHome.Data.Store;
using SmartHome.Controller.Comparators;
using SmartHome.Controller.Entities;
using SmartHome.Data;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace SmartHome.Controller.Controllers
{
    public sealed class DeviceController : IDeviceController
    {
        private readonly Dictionary<string, BoolActionDeviceEntity> _boolActionDeviceEntities;
        private readonly Dictionary<string, EventActionDeviceEntity> _eventActionDeviceEntities;

        private readonly IRepository<BoolActionDevice> _boolActionDeviceRepository;
        private readonly IRepository<BoolSensor> _boolSensorRepository;
        private readonly IRepository<NumericSensor> _numericSensorRepository;
        private readonly IRepository<EventDevice> _eventDeviceRepository;
        private readonly IRepository<EventActionDevice> _eventActionDeviceRepository;
        private readonly IRepository<Rule> _ruleRepository;

        private readonly IHistoryRepository<BoolActionDeviceHistoryItem> _boolActionDevicesHistoryRepository;
        private readonly IHistoryRepository<BoolSensorHistoryItem> _boolSensorHistoryRepository;
        private readonly IHistoryRepository<NumericSensorHistoryItem> _numericSensorHistoryRepository;
        private readonly IHistoryRepository<EventDeviceHistoryItem> _eventDeviceHistoryRepository;

        private ILogger<DeviceController> _logger;


        public DeviceController(IStoreFactory storeFactory, ILogger<DeviceController> logger)
        {
            var dataStore = storeFactory.ControllerDataStore;
            var historyStore = storeFactory.HistoryStore;
            
            _boolActionDeviceRepository = dataStore.BoolActionDevices;
            _boolSensorRepository = dataStore.BoolSensors;
            _numericSensorRepository = dataStore.NumericSensors;
            _eventDeviceRepository = dataStore.EventDevices;
            _ruleRepository = dataStore.Rules;

            _boolActionDevicesHistoryRepository = historyStore.BoolActionDeviceHistory;
            _boolSensorHistoryRepository = historyStore.BoolSensorHistory;
            _numericSensorHistoryRepository = historyStore.NumericSensorHistory;
            _eventDeviceHistoryRepository = historyStore.EventDeviceHistory;

            _logger = logger;

            _boolActionDeviceEntities = new Dictionary<string, BoolActionDeviceEntity>();
            _eventActionDeviceEntities = new Dictionary<string, EventActionDeviceEntity>();
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
                _logger.LogTrace($"Получено значение '{value.Value}' от устройства '{value.SensorName}'");
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
                _logger.LogTrace($"Получено значение '{value.Value}' от устройства '{value.SensorName}'");
                _numericSensorHistoryRepository.Save();
                return true;
            }
            else return false;
        }

        public async Task<bool> ThrowEvent(DeviceEventWrapper deviceEvent)
        {
            var now = DateTime.Now;
            var eventDevice = _eventDeviceRepository[deviceEvent.SensorName];
            if (eventDevice != null)
            {
                _logger.LogTrace($"Устройство '{deviceEvent.SensorName}' найдено");
                var rules = _ruleRepository.Where(rule => rule.Rule2EventDevices.Any(r2ed => r2ed.Device.SysName == deviceEvent.SensorName));
                var boolActionDevicesWithNewState = eventDevice.BoolDeviceActions.Select(bdea => new { bdea.Device, bdea.TargetStateMode });

                if (rules.Any(rule => CheckRule(rule)))
                {
                    _logger.LogTrace($"Правила для устройства '{deviceEvent.SensorName}' проверены. Действия доступны.");
                    foreach (var deviceWithNewState in boolActionDevicesWithNewState)
                    {
                        deviceWithNewState.Device.ActivityMode = deviceWithNewState.TargetStateMode;
                        _logger.LogInformation($"Устройству '{deviceWithNewState.Device.SysName}' присвоен режим '{deviceWithNewState.TargetStateMode}' по сигналу от '{deviceEvent.SensorName}'");
                    }
                    _eventDeviceRepository.Save();

                    var eventActionDevices = eventDevice.EventDevice2EventActionDevices.Select(ed2ead => ed2ead.EventActionDevice);
                    await CallDevices(eventActionDevices);
                    _logger.LogTrace($"Сигнал от '{deviceEvent.SensorName}' передан на исполнительные устройства");
                }

                //записать в историю
                _eventDeviceHistoryRepository.Add(new EventDeviceHistoryItem()
                {
                    CreateDate = now,
                    SysName = deviceEvent.SensorName
                });
                _eventDeviceHistoryRepository.Save();
                return true;
            }
            else return false;
        }

        /// <summary>
        /// Регистрация обработчика для исполнительного устройства
        /// TODO: нет проверки на валидность переданного наименования устройства
        /// </summary>
        /// <param name="sysName">Системное имя устройства</param>
        /// <param name="eventHadler">Обработчик</param>
        /// <returns></returns>
        public bool RegistryBoolActionDeviceHandler(string sysName, Func<bool,Task> eventHadler)
        {
            if (!_boolActionDeviceEntities.TryGetValue(sysName, out BoolActionDeviceEntity entity))
            {
                var device = _boolActionDeviceRepository[sysName];
                if (device == null) return false;

                entity = new BoolActionDeviceEntity(device, false);
                _boolActionDeviceEntities.Add(sysName, entity);
                _logger.LogInformation($"Зарегистрировано устройство '{sysName}'");
            }
            entity.OnStateChanged += eventHadler;
            _logger.LogInformation($"Устройству '{sysName}' добавлен обработчик события");

            return true;
        }

        /// <summary>
        /// Регистрация обработчика для событийного исполнительного устройства
        /// TODO: нет проверки на валидность переданного наименования устройства
        /// </summary>
        /// <param name="sysName">Системное имя устройства</param>
        /// <param name="eventHandler">Обработчик</param>
        /// <returns></returns>
        public bool RegistryEventActionDeviceHandler(string sysName, Func<Task> eventHandler)
        {
            if(!_eventActionDeviceEntities.TryGetValue(sysName, out EventActionDeviceEntity entity))
            {
                var device = _eventActionDeviceRepository[sysName];
                if (device == null) return false;

                entity = new EventActionDeviceEntity(device);
                _eventActionDeviceEntities.Add(sysName, entity);
                _logger.LogInformation($"Зарегистрировано устройство '{sysName}'");
            }
            entity.OnCallDevice += eventHandler;
            _logger.LogInformation($"Устройству '{sysName}' добавлен обработчик события");

            return true;
        }

        public async Task Refresh()
        {
            _logger.LogTrace("Обновление состояния");
            await RefreshBoolActionDevices();
        }

        private bool CheckRule(Rule rule)
        {
            return rule.Nodes.All(node =>
            {
                return node.BoolSensorConditions.All(condition => new BoolSensorConditionComparator(condition).IsRight())
                    && node.NumericSensorConditions.All(condition => new NumericSensorConditionComparator(condition).IsRight())
                    && node.TimeConditions.All(condition => new TimeConditionComparator(condition).IsRight())
                    && node.UserConditions.All(condition => new UserConditionComparator(condition).IsRight());
            });
        }

        private async Task RefreshBoolActionDevices()
        {
            var now = DateTime.Now;
            foreach (var device in _boolActionDeviceRepository)
            {
                var rulesIDList = device.Rule2BoolActionDevices.Select(r2bad => r2bad.RuleID);
                var rules = _ruleRepository.Where(rule => rulesIDList.Contains(rule.ID));
                var value = rules.Any(rule => CheckRule(rule));
                _boolActionDevicesHistoryRepository.Add(new BoolActionDeviceHistoryItem { CreateDate = now, SysName = device.SysName, Value = value });
                
                if(_boolActionDeviceEntities.TryGetValue(device.SysName, out BoolActionDeviceEntity deviceEntity))
                {
                    await deviceEntity.SetValueAsync(value);
                }
            }
        }

        private async Task CallDevices(IEnumerable<EventActionDevice> devices)
        {
            foreach(var device in devices)
            {
                if(_eventActionDeviceEntities.TryGetValue(device.SysName, out EventActionDeviceEntity entity))
                    await entity.CallAsync();
            }
        }


        /// <summary>
        /// Передает системные наименования включенных устройств
        /// </summary>
        /// <returns></returns>
        public IEnumerable<string> GetActiveBoolActionDeviceNames() => _boolActionDeviceEntities.Where(keyValuePair => keyValuePair.Value.Value).Select(keyValuePair => keyValuePair.Key);
    }
}
