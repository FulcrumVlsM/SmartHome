using System;
using System.Collections.Generic;
using System.Text;

namespace SmartHome.WebSocket.Models
{
    /// <summary>
    /// Тип устройства
    /// </summary>
    public enum DeviceType
    {
        /// <summary>
        /// Логическое устройство
        /// </summary>
        BoolActionDevice = 1,

        /// <summary>
        /// Событийное устройство
        /// </summary>
        EventActionDevice = 2
    }
}
