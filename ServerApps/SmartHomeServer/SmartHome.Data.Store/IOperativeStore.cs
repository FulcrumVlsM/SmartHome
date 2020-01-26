using SmartHome.Data.Models;

namespace SmartHome.Data.Store
{
    public interface IOperativeStore
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
        /// Репозиторий смарт-карт пользователей
        /// </summary>
        IReadOnlyRepository<SmartCard> SmartCards { get; set; }

        /// <summary>
        /// Репозиторий правил конфигурации
        /// </summary>
        IReadOnlyRepository<Rule> Rules { get; }
    }
}
