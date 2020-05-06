using SmartHome.Controller.Values;
using System.Threading.Tasks;

namespace SmartHome.Controller
{
    public interface IUserActionController
    {
        Task<bool> Initiate(SmartCardEventWrapper eventWrapper);
    }
}
