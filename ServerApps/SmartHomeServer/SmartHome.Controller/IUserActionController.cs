using SmartHome.Controller.Values;

namespace SmartHome.Controller
{
    public interface IUserActionController
    {
        bool Initiate(SmartCardEventWrapper eventWrapper);
    }
}
