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
        private readonly IRepository<EventDevice> _eventDeviceRepository;
        private readonly IRepository<Rule> _ruleRepository;
        private readonly IRepository<SmartCard> _smartCardRepository;

        private readonly IHistoryRepository<BoolActionDeviceHistoryItem> _boolActionDevicesHistoryRepository;
        private readonly IHistoryRepository<BoolSensorHistoryItem> _boolSensorHistoryRepository;
        private readonly IHistoryRepository<EventDeviceHistoryItem> _eventDeviceHistoryRepository;
        private readonly IHistoryRepository<UserActionHistoryItem> _userActionHistory;


        public DeviceController(IDataStore dataStore, IHistoryStore historyStore)
        {
            _boolActionDeviceRepository = dataStore.BoolActionDevices;
            _boolSensorRepository = dataStore.BoolSensors;
            _eventDeviceRepository = dataStore.EventDevices;
            _ruleRepository = dataStore.Rules;
            _smartCardRepository = dataStore.SmartCards;

            _boolActionDevicesHistoryRepository = historyStore.BoolActionDeviceHistory;
            _boolSensorHistoryRepository = historyStore.BoolSensorHistory;
            _eventDeviceHistoryRepository = historyStore.EventDeviceHistory;

            _boolActionDeviceEntities = new Dictionary<string, BoolActionDeviceEntity>();
            //TODO: добавить логгер
        }


        public bool SetBoolSensorValue(BoolSensorValue value)
        {
            var sensor = _boolSensorRepository.FirstOrDefault(sensor => sensor.SysName == value.SensorName);
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

        public bool ThrowEvent(string eventDeviceName)
        {
            var eventDevice = _eventDeviceRepository.FirstOrDefault(device => device.SysName == eventDeviceName);
            if (eventDevice != null)
            {
                var rules = _ruleRepository.Where(rule => rule.Rule2EventDevices.Any(r2ed => r2ed.Device.SysName == eventDeviceName));
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
                    SysName = eventDeviceName
                });
                _eventDeviceHistoryRepository.Save();
                return true;
            }
            else return false;
        }

        public bool ThrowSmartCardEvent(SmartCardEventWrapper smartCardEventWrapper)
        {

            var eventDevice = _eventDeviceRepository.FirstOrDefault(device => device.SysName == smartCardEventWrapper.EventDeviceName);
            var smartCard = _smartCardRepository.FirstOrDefault(key => key.Key == smartCardEventWrapper.CardKey);
            var user = smartCard?.User;
            if (eventDevice != null && user != null)
            {
                user.InHome = eventDevice.UserEventAction?.AssignedValue ?? user.InHome;
                _smartCardRepository.Save();
                _userActionHistory.Add(new UserActionHistoryItem()
                {
                    SmartCard = smartCard,
                    User = user,
                    Value = user.InHome
                });
                _userActionHistory.Save();
                return true;
            }
            else return false;
        }

        public bool SetNumericSensorValue(NumericSensorValue value)
        {
            throw new NotImplementedException();
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

        private void Refresh()
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

        void IDeviceController.Refresh() => Refresh();
    }
}
