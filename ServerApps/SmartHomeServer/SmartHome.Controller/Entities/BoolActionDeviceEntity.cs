using SmartHome.Common.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartHome.Controller.Entities
{
    public class BoolActionDeviceEntity
    {
        private BoolActionDeviceEntity() { }

        
        public string SysName { get; set; }

        public DeviceStateMode DeviceStateMode { get; set; }

        public DateTime LastActivityDate { get; set; }

        public string Value { get; set; }

        
        public event Action<bool> OnStateChanged;


        //добавить фабричный метод
    }
}
