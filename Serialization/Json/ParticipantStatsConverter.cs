using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RiotApi.Entity.Matches;

namespace RiotApi.Serialization.Json
{
    public class ParticipantStatsConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return typeof (MatchParticipantStats).IsAssignableFrom(objectType);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JObject jObject = JObject.Load(reader);
            MatchParticipantStats result = new MatchParticipantStats();
            serializer.Populate(jObject.CreateReader(), result);
            result.Items = new List<int>(new[]
            {
                (int) jObject["item0"],
                (int) jObject["item1"],
                (int) jObject["item2"],
                (int) jObject["item3"],
                (int) jObject["item4"],
                (int) jObject["item5"],
                (int) jObject["item6"]
            });
            return result;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}