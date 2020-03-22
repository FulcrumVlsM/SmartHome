using SmartHome.Controller.Values;
using SmartHome.Data;
using SmartHome.Data.Models;
using SmartHome.Data.Store;
using System;

namespace SmartHome.Controller.Controllers
{
    public class UserActionController : IUserActionController
    {
        private readonly IUserValidator _validator;
        private readonly IRepository<EventDevice> _eventDeviceRepository;
        private readonly IRepository<User> _userRepository;
        private readonly IDeviceController _controller;

        public UserActionController(IDataStore dataStore, IHistoryStore historyStore, IUserValidator validator, IDeviceController controller)
        {
            _eventDeviceRepository = dataStore.EventDevices;
            _userRepository = dataStore.Users;
            _validator = validator;
            _controller = controller;
        }
        
        
        public bool Initiate(SmartCardEventWrapper eventWrapper)
        {
            if (_validator.TryValidate(eventWrapper.CardKey, out User preUser))
            {
                User user = _userRepository[preUser];
                EventDevice device = _eventDeviceRepository[eventWrapper.EventDeviceName];
                if (device == null) return false;
                user.InHome = device.UserEventAction.AssignedValue;
                _userRepository.Save();
                
                DeviceEventWrapper deviceEventWrapper = new DeviceEventWrapper(eventWrapper.EventDeviceName);
                return _controller.ThrowEvent(deviceEventWrapper);
            }
            else return false;
        }
    }
}
