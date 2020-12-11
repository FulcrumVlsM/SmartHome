namespace SmartHome.WebSocket.Models
{
    /// <summary>
    /// Тип ответа для устройства подключенного по webSocket протоколу
    /// </summary>
    public enum ResponseType
    {
        /// <summary>
        /// Ожидание обновления от устройства
        /// </summary>
        StandBy = 0,

        /// <summary>
        /// Обновление состояния от контроллера
        /// </summary>
        Update = 1,

        /// <summary>
        /// Не удалось подключиться к контроллеру
        /// </summary>
        Incorrect = 2,

        /// <summary>
        /// Ошибка неизвестного характера
        /// </summary>
        Error = 3
    }
}
