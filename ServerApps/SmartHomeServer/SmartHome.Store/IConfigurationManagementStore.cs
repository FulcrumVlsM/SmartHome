using SmartHome.Data;
using SmartHome.Data.Models;

namespace SmartHome.Store
{
    /// <summary>
    /// Интерфейс хранилища конфигурации
    /// </summary>
    public interface IConfigurationManagementStore
    {
        /// <summary>
        /// Репозиторий исполнительных устройств
        /// </summary>
        IRepository<IBoolActionDevice> BoolActionDevices { get; }

        /// <summary>
        /// Репозиторий логических датчиков
        /// </summary>
        IRepository<IBoolSensor> BoolSensors { get; }

        /// <summary>
        /// Репозиторий событийных устройств
        /// </summary>
        IRepository<IEventDevice> EventDevices { get; }

        /// <summary>
        /// Репозиторий измерительных датчиков
        /// </summary>
        IRepository<INumericSensor> NumericSensors { get; }

        /// <summary>
        /// Репозиторий правил конфигурации
        /// </summary>
        IRepository<IRule> Rules { get; }
    }
}
