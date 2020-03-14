using SmartHome.Data;
using SmartHome.Data.Models;
using SmartHome.Data.Store;

namespace SmartHome.Controller.Validators
{
    class UserValidator : IUserValidator
    {
        private readonly IRepository<SmartCard> _smartCardRepository;

        public UserValidator(IDataStore dataStore) => _smartCardRepository = dataStore.SmartCards;

        bool IUserValidator.TryValidate(string cardKey, out User user)
        {
            user = Validate(cardKey);
            return user != null ? true : false;
        }

        User IUserValidator.Validate(string cardKey) => Validate(cardKey);


        private User Validate(string cardKey) => _smartCardRepository[cardKey]?.User;
    }
}
