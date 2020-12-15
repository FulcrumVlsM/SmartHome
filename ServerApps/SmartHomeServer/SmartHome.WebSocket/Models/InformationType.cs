namespace SmartHome.WebSocket.Models
{
    /// <summary>
    /// Указывает какое действие выполнило устройство по команде от контроллера
    /// </summary>
    public enum InformationType
    {
        /// <summary>
        /// Не указано
        /// </summary>
        None = 0,

        /// <summary>
        /// Команда принята. Устройство выполнит команду позже
        /// </summary>
        Received = 1,

        /// <summary>
        /// Команда принята и выполнена
        /// </summary>
        Applied = 2,

        /// <summary>
        /// Команда принята, но не будет выполнена
        /// </summary>
        NotApplied = 3
    }
}
