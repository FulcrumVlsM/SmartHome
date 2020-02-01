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
        IRepository<BoolActionDevice> BoolActionDevices { get; }

        /// <summary>
        /// Репозиторий логических датчиков
        /// </summary>
        IRepository<BoolSensor> BoolSensors { get; }

        /// <summary>
        /// Репозиторий событийных устройств
        /// </summary>
        IRepository<EventDevice> EventDevices { get; }

        /// <summary>
        /// Репозиторий измерительных датчиков
        /// </summary>
        IRepository<NumericSensor> NumericSensors { get; }

        /// <summary>
        /// Репозиторий пользователей
        /// </summary>
        IRepository<User> Users { get; set; }

        /// <summary>
        /// Репозиторий правил конфигурации
        /// </summary>
        IRepository<Rule> Rules { get; }
    }
}
