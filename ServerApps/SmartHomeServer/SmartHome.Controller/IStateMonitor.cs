using SmartHome.Controller.Models;

namespace SmartHome.Controller
{
    /// <summary>
    /// Интерфейс для получения данных мониторинга
    /// </summary>
    public interface IStateMonitor
    {
        /// <summary>
        /// Получить данные
        /// </summary>
        /// <returns></returns>
        Summary GetSummary();
    }
}
