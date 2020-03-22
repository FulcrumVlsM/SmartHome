using SmartHome.Data.Models;

namespace SmartHome.Controller
{
    public interface IUserValidator
    {
        internal User Validate(string cardKey);

        internal bool TryValidate(string cardKey, out User user);
    }
}
