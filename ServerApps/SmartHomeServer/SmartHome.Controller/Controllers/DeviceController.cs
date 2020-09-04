using System;
using System.Collections.Generic;
using System.Linq;
using SmartHome.Controller.Values;
using SmartHome.Data.Models;
using SmartHome.Data.Store;
using SmartHome.Controller.Comparators;
using SmartHome.Controller.Entities;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace SmartHome.Controller.Controllers
{
    public sealed class DeviceController : IDeviceController
    {
        private readonly Dictionary<string, BoolActionDeviceEntity> _boolActionDeviceEntities;
        private readonly Dictionary<string, EventActionDeviceEntity> _eventActionDeviceEntities;
        private readonly IStoreFactory _storeFactory;
        private ILogger<DeviceController> _logger;


        public DeviceController(IStoreFactory storeFactory, ILogger<DeviceController> logger)
        {
            _storeFactory = storeFactory;
            _logger = logger;
            _boolActionDeviceEntities = new Dictionary<string, BoolActionDeviceEntity>();
            _eventActionDeviceEntities = new Dictionary<string, EventActionDeviceEntity>();
        }



        private IDataStore DataStore => _storeFactory.ControllerDataStore;

        private IHistoryStore HistoryStore => _storeFactory.HistoryStore;


        public bool PassValue(BoolSensorValue value)
        {
            var boolSensorRepository = DataStore.BoolSensors;
            var boolSensorHistoryRepository = HistoryStore.BoolSensorHistory;
            
            var sensor = boolSensorRepository[value.SensorName];
            if (sensor != null)
            {
                sensor.Value = value.Value;
                boolSensorRepository.Save();
                boolSensorHistoryRepository.Add(new BoolSensorHistoryItem()
                {
                    CreateDate = DateTime.Now,
                    SysName = sensor.SysName,
                    Value = sensor.Value
                });
                boolSensorHistoryRepository.Save();
                _logger.LogTrace($"Получено значение '{value.Value}' от устройства '{value.SensorName}'");
                return true;
            }
            else return false;
        }

        public bool PassValue(NumericSensorValue value)
        {
            var numericSensorRepository = DataStore.NumericSensors;
            var numericSensorHistoryRepository = HistoryStore.NumericSensorHistory;

            var sensor = numericSensorRepository[value.SensorName];
            if (sensor != null)
            {
                sensor.Value = value.Value;
                numericSensorRepository.Save();

                numericSensorHistoryRepository.Add(new NumericSensorHistoryItem()
                {
                    SysName = sensor.SysName,
                    CreateDate = DateTime.Now,
                    Value = value.Value
                });
                _logger.LogTrace($"Получено значение '{value.Value}' от устройства '{value.SensorName}'");
                numericSensorHistoryRepository.Save();
                return true;
            }
            else return false;
        }

        public async Task<bool> ThrowEvent(DeviceEventWrapper deviceEvent)
        {
            var dataStore = DataStore;
            var eventDeviceRepository = dataStore.EventDevices;
            var ruleRepository = dataStore.Rules;
            var eventDeviceHistoryRepository = HistoryStore.EventDeviceHistory;
            
            var now = DateTime.Now;
            var eventDevice = eventDeviceRepository[deviceEvent.SensorName];
            if (eventDevice != null)
            {
                _logger.LogTrace($"Устройство '{deviceEvent.SensorName}' найдено");
                var rules = ruleRepository.Where(rule => rule.Rule2EventDevices.Any(r2ed => r2ed.Device.SysName == deviceEvent.SensorName)).ToList();
                var boolActionDevicesWithNewState = eventDevice.BoolDeviceActions.Select(bdea => new { bdea.Device, bdea.TargetStateMode }).ToList();

                if (rules.Any(rule => CheckRule(rule)))
                {
                    _logger.LogTrace($"Правила для устройства '{deviceEvent.SensorName}' проверены. Действия доступны.");
                    foreach (var deviceWithNewState in boolActionDevicesWithNewState)
                    {
                        deviceWithNewState.Device.ActivityMode = deviceWithNewState.TargetStateMode;
                        _logger.LogInformation($"Устройству '{deviceWithNewState.Device.SysName}' присвоен режим '{deviceWithNewState.TargetStateMode}' по сигналу от '{deviceEvent.SensorName}'");
                    }
                    eventDeviceRepository.Save();

                    var eventActionDevices = eventDevice.EventDevice2EventActionDevices.Select(ed2ead => ed2ead.EventActionDevice).ToList();
                    await CallDevices(eventActionDevices);
                    _logger.LogTrace($"Сигнал от '{deviceEvent.SensorName}' передан на исполнительные устройства");
                }

                //записать в историю
                eventDeviceHistoryRepository.Add(new EventDeviceHistoryItem()
                {
                    CreateDate = now,
                    SysName = deviceEvent.SensorName
                });
                eventDeviceHistoryRepository.Save();
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
                var boolActionDeviceRepository = DataStore.BoolActionDevices;
                var device = boolActionDeviceRepository[sysName];
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
                var eventActionDeviceRepository = DataStore.EventActionDevices;
                var device = eventActionDeviceRepository[sysName];
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
            return rule.Nodes.ToList().All(node =>
            {
                return node.BoolSensorConditions.All(condition => new BoolSensorConditionComparator(condition).IsRight())
                    && node.NumericSensorConditions.All(condition => new NumericSensorConditionComparator(condition).IsRight())
                    && node.TimeConditions.All(condition => new TimeConditionComparator(condition).IsRight())
                    && node.UserConditions.All(condition => new UserConditionComparator(condition).IsRight());
            });
        }

        private async Task RefreshBoolActionDevices()
        {
            var dataStore = DataStore;
            var boolActionDeviceRepository = dataStore.BoolActionDevices;
            var ruleRepository = dataStore.Rules;
            var boolActionDevicesHistoryRepository = HistoryStore.BoolActionDeviceHistory;
            var now = DateTime.Now;
            foreach (var device in boolActionDeviceRepository)
            {
                var rulesIDList = device.Rule2BoolActionDevices.Select(r2bad => r2bad.RuleID).ToList();
                var rules = ruleRepository.AsEnumerable().Where(rule => rulesIDList.Contains(rule.ID));
                var value = rules.Any(rule => CheckRule(rule));
                boolActionDevicesHistoryRepository.Add(new BoolActionDeviceHistoryItem { CreateDate = now, SysName = device.SysName, Value = value });
                
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
