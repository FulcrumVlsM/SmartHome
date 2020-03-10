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

namespace SmartHome.Controller
{
    public sealed class DeviceController : IDeviceController
    {        
        private readonly IDataStore _dataStore;
        private readonly IHistoryStore _historyStore;
        private readonly Dictionary<string, BoolActionDeviceEntity> _boolActionDeviceEntities;

        public DeviceController(IDataStore dataStore, IHistoryStore historyStore)
        {
            _dataStore = dataStore;
            _historyStore = historyStore;
            _boolActionDeviceEntities = new Dictionary<string, BoolActionDeviceEntity>();
            //TODO: добавить логгер
        }


        public bool SetBoolSensorValue(BoolSensorValue value)
        {
            var boolSensorRepository = _dataStore.BoolSensors;
            var sensor = _dataStore.BoolSensors.FirstOrDefault(sensor => sensor.SysName == value.SensorName);
            if (sensor != null)
            {
                sensor.Value = value.Value;
                boolSensorRepository.Save();
                _historyStore.BoolSensorHistory.Add(new BoolSensorHistoryItem()
                {
                    CreateDate = DateTime.Now,
                    SysName = sensor.SysName,
                    Value = sensor.Value
                });
                return true;
            }
            else return false;
        }

        public bool ThrowEvent(string eventDeviceName)
        {
            var eventRepository = _dataStore.EventDevices;
            var ruleRepository = _dataStore.Rules;
            var historyRepository = _historyStore.EventDeviceHistory;
            var eventDevice = eventRepository.FirstOrDefault(device => device.SysName == eventDeviceName);
            if (eventDevice != null)
            {
                //найти все связанные устройства, установить значения
                var rules = ruleRepository.Where(rule => rule.Rule2EventDevices.Any(r2ed => r2ed.Device.SysName == eventDeviceName));
                var boolActionDevices = eventDevice.Actions.Select(bdea => new { bdea.Device, bdea.TargetStateMode });

                if (CheckRules(rules))
                {
                    foreach(var device in boolActionDevices)
                    {
                        //TODO
                    }
                }
                
                //записать в историю
                historyRepository.Add(new EventDeviceHistoryItem()
                {
                    CreateDate = DateTime.Now,
                    SysName = eventDeviceName
                });
                return true;
            }
            else return false;
        }

        public bool ThrowSmartCardEvent(SmartCardEventWrapper smartCardEventWrapper)
        {
            throw new NotImplementedException();
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
                var device = _dataStore.BoolActionDevices.FirstOrDefault(device => device.SysName == sysName);
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
            foreach (var device in _dataStore.BoolActionDevices)
            {
                IEnumerable<int> rulesIDList = device.Rule2BoolActionDevices.Select(x => x.RuleID);
                var rules = _dataStore.Rules.Where(rule => rulesIDList.Contains(rule.ID));

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
