using System;
using System.Collections.Generic;
using System.Text;
using SmartHome.Controller.Values;
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

        public bool SetNumericSensorValue(NumericSensorValue value)
        {
            throw new NotImplementedException();
        }
    }
}
