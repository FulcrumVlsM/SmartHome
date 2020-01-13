namespace SmartHome.Common.Enums
{
    /// <summary>
    /// Режим работы исполнительного устройства
    /// </summary>
    public enum DeviceStateMode
    {
        /// <summary>
        /// Выключен постоянно
        /// </summary>
        Disable = 0,

        /// <summary>
        /// Включен постоянно
        /// </summary>
        Enable = 1,

        /// <summary>
        /// Автоматически (по описанным правилам)
        /// </summary>
        Auto = 2
    }
}
