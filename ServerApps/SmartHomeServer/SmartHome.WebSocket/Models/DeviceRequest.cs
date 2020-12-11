using Newtonsoft.Json;
using System.Collections.Generic;

namespace SmartHome.WebSocket.Models
{
    /// <summary>
    /// Модель запроса при подключении к контроллеру
    /// </summary>
    public class DeviceRequest
    {
        [JsonProperty(PropertyName = "configurations")]
        public List<Configuration> Configurations { get; set; }
    }
}
