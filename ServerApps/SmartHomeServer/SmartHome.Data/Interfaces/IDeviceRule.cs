using System;
using System.Collections.Generic;
using System.Text;

namespace SmartHome.Data.Interfaces
{
    /// <summary>
    /// Интерфейс описания правил для исполнительных устройств
    /// </summary>
    public interface IDeviceRule
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        int ID { get; set; }

        /// <summary>
        /// Публичное имя правила
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// Дата и время создания правила
        /// </summary>
        DateTime CreateDate { get; set; }


        /// <summary>
        /// Связанные исполнительные устройства
        /// </summary>
        List<IBoolDevice> Devices { get; set; }

        /// <summary>
        /// Элементы условий. Каждый узел хранит условия, между которыми выполняется логическое И. 
        /// Между самими узлами действует логическое ИЛИ.
        /// </summary>
        List<IRuleNode> Nodes { get; set; }
    }
}
