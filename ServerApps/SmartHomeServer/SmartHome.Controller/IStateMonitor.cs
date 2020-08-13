using SmartHome.Controller.Models;

namespace SmartHome.Controller
{
    public interface IStateMonitor
    {
        Summary GetSummary();
    }
}
