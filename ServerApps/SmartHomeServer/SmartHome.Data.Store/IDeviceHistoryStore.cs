using SmartHome.Data.Models;

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
        IRepository<BoolActionDeviceHistory> BoolActionDeviceHistory { get; }

        /// <summary>
        /// Репозиторий логов логических датчиков
        /// </summary>
        IRepository<BoolSensorHistory> BoolSensorHistory { get; }

        /// <summary>
        /// Репозиторий логов событийных устройств
        /// </summary>
        IRepository<EventDeviceHistory> EventDeviceHistory { get; }

        /// <summary>
        /// Репозиторий логов измерительных датчиков
        /// </summary>
        IRepository<NumericSensorHistory> NumericSensorHistory { get; }

        /// <summary>
        /// Репозиторий логов активности пользователей
        /// </summary>
        IRepository<UserActionHistory> UserActionHistory { get; }
    }
}
