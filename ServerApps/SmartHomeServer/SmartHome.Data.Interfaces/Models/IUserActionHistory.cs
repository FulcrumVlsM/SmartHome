using System;
using System.Collections.Generic;
using System.Text;

namespace SmartHome.Data.Interfaces.Models
{
    public interface IUserActionHistory
    {
        int ID { get; set; }

        bool Value { get; set; }

        IUser User { get; set; }

        ISmartCard SmartCard { get; set; }
    }
}
