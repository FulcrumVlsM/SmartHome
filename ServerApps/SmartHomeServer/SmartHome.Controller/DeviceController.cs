using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SmartHome.Controller.Values;
using SmartHome.Data.Models;
using SmartHome.Data.Store;
using SmartHome.Controller.Comparators;

namespace SmartHome.Controller
{
    public sealed class DeviceController
    {
        private readonly IDataStore _dataStore;
        private readonly IHistoryStore _historyStore;

        public DeviceController(IDataStore dataStore, IHistoryStore historyStore)
        {
            _dataStore = dataStore;
            _historyStore = historyStore;
            //TODO: добавить логгер
        }


        public bool SetBoolSensorValue(BoolSensorValue value)
        {
            throw new NotImplementedException();
        }

        public bool ThrowEvent(string eventDeviceName)
        {
            throw new NotImplementedException();
        }

        public bool ThrowSmartCardEvent(SmartCardEventWrapper smartCardEventWrapper)
        {
            throw new NotImplementedException();
        }

        public bool SetNumericSensorValue(NumericSensorValue value)
        {
            throw new NotImplementedException();
        }


        public event Action<string, bool> BoolActionDeviceEvent;



        private IEnumerable<BoolActionDevice> GetAffectedBoolDevices(string sensorName)
        {
            return new List<BoolActionDevice>();
        }

        private void Refresh(IEnumerable<BoolActionDevice> affectedDevices)
        {
            foreach(var affectedDevice in affectedDevices)
            {
                //найти правила
                IEnumerable<int> rulesIDList = affectedDevice.Rule2BoolActionDevices.Select(x => x.RuleID);
                var rules = _dataStore.Rules.Where(rule => rulesIDList.Contains(rule.ID));

                //выяснить требуемое значение
                bool requiredValue = rules.Any(rule => rule.Nodes.All(node => node.NumericSensorConditions.All(condition => new NumericSensorConditionComparator(condition).IsRight())));

                //если не совпадает, обновить и сгенерить событие
            }
        }
    }
}
