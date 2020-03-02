using SmartHome.Data.Store.Stores;

namespace SmartHome.Data.Store.Factories
{
    public class EFStoreFactory : IStoreFactory
    {
        public IDataStore ControllerDataStore => new EFControllerStore();

        public IDataStore ConfigurationDataStore => new EFSimpleDataStore();

        public IHistoryStore HistoryStore => new EFHistoryStore();
    }
}
