using SmartHome.Data.Interfaces.Models;

namespace SmartHome.Data.Store
{
    /// <summary>
    /// Интерфейс хранилища логов устройств
    /// </summary>
    public interface IDeviceHistoryStore
    {
        /// <summary>
        /// Репозиторий логов логических исполнительных устройств
        /// </summary>
        IRepository<IBoolActionDeviceHistory> BoolActionDeviceHistory { get; }

        /// <summary>
        /// Репозиторий логов логических датчиков
        /// </summary>
        IRepository<IBoolSensorHistory> BoolSensorHistory { get; }

        /// <summary>
        /// Репозиторий логов событийных устройств
        /// </summary>
        IRepository<IEventDeviceHistory> EventDeviceHistory { get; }

        /// <summary>
        /// Репозиторий логов измерительных датчиков
        /// </summary>
        IRepository<INumericSensorHistory> NumericSensorHistory { get; }

        /// <summary>
        /// Репозиторий логов активности пользователей
        /// </summary>
        IRepository<IUserActionHistory> UserActionHistory { get; }
    }
}
