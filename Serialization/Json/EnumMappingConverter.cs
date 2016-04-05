using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Newtonsoft.Json;

namespace RiotApi.Serialization.Json
{
    internal class EnumMapper<TEnum>
    {
        private static readonly BindingFlags GetAllFields = BindingFlags.DeclaredOnly | BindingFlags.Public |
                                                            BindingFlags.Static;

        private readonly Dictionary<string, TEnum> _keysToValues =
            new Dictionary<string, TEnum>(StringComparer.OrdinalIgnoreCase);

        private readonly Dictionary<TEnum, string> _valuesToKeys =
            new Dictionary<TEnum, string>();

        public EnumMapper()
        {
            var fields = from f in typeof(TEnum).GetFields(GetAllFields)
                         select new
                         {
                             field = f,
                             attr = f.GetCustomAttribute<MappingAttribute>(),
                             value = (TEnum)f.GetValue(null)
                         };

            foreach (var f in fields)
            {
                _keysToValues[f.field.Name] = f.value;
                _valuesToKeys[f.value] = f.field.Name;
                if (f.attr != null)
                {
                    _keysToValues[f.attr.Name] = f.value;
                    _valuesToKeys[f.value] = f.attr.Name;
                }
            }
        }

        public string GetKey(object value)
        {
            TEnum v = (TEnum) value;
            return _valuesToKeys.ContainsKey(v) ? _valuesToKeys[v] : null;
        }

        public object GetValue(string name)
        {
            return _keysToValues.ContainsKey(name) ? (object) _keysToValues[name] : null;
        }
    }

    internal static class EnumMappingRegistry
    {
        private static readonly object LockObject = new object();
        private static readonly Dictionary<Type, object> Registry = new Dictionary<Type, object>();

        public static EnumMapper<TEnum> GetMapper<TEnum>()
        {
            lock (LockObject)
            {
                object value;

                if (!Registry.TryGetValue(typeof(TEnum), out value))
                {
                    value = new EnumMapper<TEnum>();
                    Registry.Add(typeof(TEnum), value);
                }

                return (EnumMapper<TEnum>)value;
            }
        }
    }

    public class EnumMappingConverter<TEnum> : JsonConverter
    {
        private readonly EnumMapper<TEnum> _mapper; 

        public EnumMappingConverter()
        {
            if (!typeof (TEnum).IsEnum)
            {
                throw new NotSupportedException("Non-Enum types are unsupported.");
            }
            _mapper = EnumMappingRegistry.GetMapper<TEnum>();
        }

        public override bool CanConvert(Type objectType)
        {
            return typeof(TEnum) == objectType;
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.String)
            {
                string s = (string) reader.Value;
                return _mapper.GetValue(s);
            }
            return null;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            serializer.Serialize(writer, _mapper.GetKey(value));
        }
    }
}