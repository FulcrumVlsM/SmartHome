using SmartHome.Controller.Entities;

namespace SmartHome.Controller
{
    /// <summary>
    /// Интерфейс контроллера умного дома
    /// </summary>
    public interface IDeviceController
    {
        /// <summary>
        /// Принять указанное значение от датчика
        /// </summary>
        /// <param name="boolSensor">Логический датчик</param>
        /// <param name="value">Значение</param>
        void SetNewValue(BoolSensorEntity boolSensor, bool value);

        /// <summary>
        /// Принять указанное значение от датчика
        /// </summary>
        /// <param name="numericSensor">Измерительный датчик</param>
        /// <param name="value">Значение</param>
        void SetNewValue(NumericSensorEntity numericSensor, float value);

        /// <summary>
        /// Привязать исполнительное устройство
        /// </summary>
        /// <param name="boolActionDevice"></param>
        void Bind(BoolActionDeviceEntity boolActionDevice);
        
        /// <summary>
        /// Обработать сигнал от событийного устройства
        /// </summary>
        /// <param name="eventDevice"></param>
        void HandleEvent(EventDeviceEntity eventDevice);
        
        /// <summary>
        /// Запустить контроллер
        /// </summary>
        void Start();
        
        /// <summary>
        /// Остановить контроллер
        /// </summary>
        void Stop();
    }
}
