using SmartHome.Data.Interfaces.Models;

namespace SmartHome.Data.Store
{
    public interface IOperativeStore
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
        /// Репозиторий пользователей
        /// </summary>
        IRepository<IUser> Users { get; set; }

        /// <summary>
        /// Репозиторий смарт-карт пользователей
        /// </summary>
        IReadOnlyRepository<ISmartCard> SmartCards { get; set; }

        /// <summary>
        /// Репозиторий правил конфигурации
        /// </summary>
        IReadOnlyRepository<IRule> Rules { get; }
    }
}
