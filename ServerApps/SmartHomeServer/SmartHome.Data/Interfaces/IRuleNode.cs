using System;
using System.Collections.Generic;
using System.Text;

namespace SmartHome.Data.Interfaces
{
    /// <summary>
    /// Интерфейс элемента условия правила для исполнительных устройств. 
    /// Между всеми элементами действует логическое И.
    /// </summary>
    public interface IRuleNode
    {
        int RuleID { get; set; }

        //TODO: здесь будут списки различных типов условий, но я их еще не описал
    }
}
