using SmartHome.Data.Store.Stores;

namespace SmartHome.Data.Store.Factories
{
    public class EFStoreFactory : IStoreFactory
    {
        private readonly string _connectionString;

        public EFStoreFactory(string connectionString) => _connectionString = connectionString;
        
        
        public IDataStore ControllerDataStore => new EFControllerStore(_connectionString);

        public IDataStore ConfigurationDataStore => new EFSimpleDataStore(_connectionString);

        public IHistoryStore HistoryStore => new EFHistoryStore(_connectionString);
    }
}
