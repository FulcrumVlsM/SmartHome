using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SmartHome.Controller.Values;
using SmartHome.Data.Models;
using SmartHome.Data.Store;

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
    }
}
