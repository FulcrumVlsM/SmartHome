using AutoMapper;
using SmartHome.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SmartHome.WebApp.Extensions
{
    public class BoolActionDeviceToDictionaryConverter : ITypeConverter<IEnumerable<NumericSensorHistoryItem>, Dictionary<DateTime, float>>
    {
        public Dictionary<DateTime, float> Convert(IEnumerable<NumericSensorHistoryItem> source, Dictionary<DateTime, float> destination, ResolutionContext context) =>
            source.ToDictionary(item => item.CreateDate, item => item.Value);
    }
}
