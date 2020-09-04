using AutoMapper;
using SmartHome.Controller.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SmartHome.WebApp.Extensions
{
    public class BoolActionDeviceToDictionaryConverter : ITypeConverter<IEnumerable<NumericSensorGroupedHistoryItem>, Dictionary<DateTime, float>>
    {
        public Dictionary<DateTime, float> Convert(IEnumerable<NumericSensorGroupedHistoryItem> source, Dictionary<DateTime, float> destination, ResolutionContext context) =>
            source.ToDictionary(item => item.DateTime, item => item.Value);
    }
}
