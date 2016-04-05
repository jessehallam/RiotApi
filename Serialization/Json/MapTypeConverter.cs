using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using RiotApi.Entity.Matches;

namespace RiotApi.Serialization.Json
{
    public class MapTypeConverter : JsonConverter
    {
        private static readonly Dictionary<int, MapType> Mappings = new Dictionary<int, MapType>()
        {
            {1, MapType.SummonersRift},      // Original Summoner Variant
            {2, MapType.SummonersRift},      // Original Autumn Variant
            {3, MapType.TheProvingGrounds},  // Tutorial Map
            {4, MapType.TwistedTreeline},    // Original Version
            {8, MapType.TheCrystalScar},     // Dominion Map
            {10, MapType.TwistedTreeline},   // Current Version
            {11, MapType.SummonersRift},     // Current Version
            {12, MapType.HowlingAbyss},      // ARAM Map
            {14, MapType.ButchersBridge}     // ARAM Map
        };

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof (MapType);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Integer)
            {
                int value = serializer.Deserialize<int>(reader);
                MapType result;
                return Mappings.TryGetValue(value, out result) ? (object) result : null;
            }
            return null;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            MapType val = (MapType) value;
            serializer.Serialize(writer, (from kvp in Mappings
                where kvp.Value == val
                select kvp.Key).First());
        }
    }
}