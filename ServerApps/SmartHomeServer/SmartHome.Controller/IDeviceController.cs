using SmartHome.Controller.Entities;
using SmartHome.Controller.Values;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartHome.Controller
{
    /// <summary>
    /// Интерфейс контроллера УД
    /// </summary>
    public interface IDeviceController
    {
        /// <summary>
        /// Передает значение от логического датчика
        /// </summary>
        /// <param name="value">Модель, содержащая значение датчика</param>
        /// <returns></returns>
        bool PassValue(BoolSensorValue value);

        /// <summary>
        /// Передает значение от измеряющего датчика
        /// </summary>
        /// <param name="value">Модель, содержащая значение датчика</param>
        /// <returns></returns>
        bool PassValue(NumericSensorValue value);

        /// <summary>
        /// Вызвать событие
        /// </summary>
        /// <param name="deviceEvent">Устройство, которое вызвало событие</param>
        /// <returns></returns>
        Task<bool> ThrowEvent(DeviceEventWrapper deviceEvent);

        /// <summary>
        /// Список активных устройств
        /// </summary>
        IReadOnlyCollection<BoolActionDeviceEntity> ActiveBoolActionDevices { get; }

        /// <summary>
        /// Получить сущность исполняющего устройства, привязанную к данному контроллеру
        /// </summary>
        /// <param name="sysName">Системное наименование устройства</param>
        /// <param name="entity">Сущность устройства, привязанная к контроллеру</param>
        /// <returns></returns>
        bool TryGetBoolActionDeviceEntity(string sysName, out BoolActionDeviceEntity entity);

        /// <summary>
        /// Получить сущность событийного устройства, привязанного к контроллеру
        /// </summary>
        /// <param name="sysName">Системное наименование устройства</param>
        /// <param name="entity">Сущность устройства, привязанная к контроллеру</param>
        /// <returns></returns>
        bool TryGetEventActionDeviceEntity(string sysName, out EventActionDeviceEntity entity);

        /// <summary>
        /// Обновить состояние
        /// </summary>
        /// <returns></returns>
        Task Refresh();
    }
}
