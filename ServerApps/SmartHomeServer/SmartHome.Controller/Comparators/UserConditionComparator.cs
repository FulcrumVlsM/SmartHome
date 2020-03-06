using SmartHome.Data.Models;
using System;

namespace SmartHome.Controller.Comparators
{
    internal class UserConditionComparator : IComparator
    {
        private UserCondition _condition;

        public UserConditionComparator(UserCondition condition) => _condition = condition ?? throw new ArgumentNullException(nameof(condition));


        public bool IsRight() => _condition.User.InHome == _condition.Value;
    }
}
