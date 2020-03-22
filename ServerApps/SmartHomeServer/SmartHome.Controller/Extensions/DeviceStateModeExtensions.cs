using SmartHome.Common.Enums;
using System;

namespace SmartHome.Controller.Extensions
{
    internal static class DeviceStateModeExtensions
    {
        internal static bool GetTargetValue(this DeviceStateMode deviceStateMode, bool value)
        {
            return deviceStateMode switch
            {
                DeviceStateMode.Enable => true,
                DeviceStateMode.Disable => false,
                DeviceStateMode.Auto => value,
                _ => throw new Exception($"Значение отсутствует в перечислении {nameof(DeviceStateMode)}"),
            };
        }
    }
}
