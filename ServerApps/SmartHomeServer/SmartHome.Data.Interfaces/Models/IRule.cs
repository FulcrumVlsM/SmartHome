using System;
using System.Collections.Generic;
using System.Text;

namespace SmartHome.Data.Interfaces.Models
{
    /// <summary>
    /// Интерфейс описания правил для конфигурации устройств
    /// </summary>
    public interface IRule
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
        List<IBoolActionDevice> Devices { get; set; }

        /// <summary>
        /// Связанные событийные устройства
        /// </summary>
        List<IEventDevice> EventDevices { get; set; }

        /// <summary>
        /// Элементы условий. Каждый узел хранит условия, между которыми выполняется логическое И. 
        /// Между самими узлами действует логическое ИЛИ.
        /// </summary>
        List<IRuleNode> Nodes { get; set; }
    }
}
