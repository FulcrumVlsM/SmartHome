namespace SmartHome.Data.Store
{
    /// <summary>
    /// Абстрактная фабрика хранилищ
    /// </summary>
    public interface IStoreFactory
    {
        /// <summary>
        /// Хранилище для контроллера
        /// </summary>
        IDataStore ControllerDataStore { get; }

        /// <summary>
        /// Хранилище, предназначенное для конфигурации компонентов
        /// </summary>
        IDataStore ConfigurationDataStore { get; }

        /// <summary>
        /// Хранилище истории работы устройств
        /// </summary>
        IHistoryStore HistoryStore { get; }
    }
}
