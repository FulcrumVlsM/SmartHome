using SmartHome.Data.Store.Stores;

namespace SmartHome.Data.Store.Factories
{
    public class EFStoreFactory : IStoreFactory
    {
        private readonly string _connectionString;

        public EFStoreFactory(string connectionString) => _connectionString = connectionString;

        private IDataStore _controllerDataStore = null;
        public IDataStore ControllerDataStore
        {
            get
            {
                if(_controllerDataStore == null)
                {
                    _controllerDataStore = new EFControllerStore(_connectionString);
                }
                return _controllerDataStore;
            }
        }

        public IDataStore ConfigurationDataStore => new EFSimpleDataStore(_connectionString);

        public IHistoryStore HistoryStore => new EFHistoryStore(_connectionString);
    }
}
