using SmartHome.Data.Interfaces.Models;

namespace SmartHome.Controller.Entities
{
    public class EventDeviceEntity
    {
        private readonly IEventDevice _device;
        private readonly IDeviceController _controller;

        internal EventDeviceEntity(IEventDevice device, IDeviceController controller)
        {
            _device = device;
            _controller = controller;
        }


        /// <summary>
        /// Системное имя устройства
        /// </summary>
        public string SysName => _device.SysName;


        /// <summary>
        /// Сгенерировать событие
        /// </summary>
        public void CreateEvent() => _controller.HandleEvent(this);
    }
}
