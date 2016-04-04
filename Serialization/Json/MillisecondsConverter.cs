using System;
using Newtonsoft.Json;

namespace RiotApi.Serialization.Json
{
    public class MillisecondsConverter : JsonConverter
    {
        private static readonly DateTimeOffset EpochTime = new DateTimeOffset(1970, 1, 1, 0, 0, 0, TimeSpan.Zero);

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            DateTimeOffset dto = (DateTimeOffset) value;
            TimeSpan ts = dto - EpochTime;
            serializer.Serialize(writer, (long) ts.TotalMilliseconds);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Integer)
            {
                long value = Convert.ToInt64(reader.Value);
                return EpochTime.AddMilliseconds(value);
            }
            return null;
        }

        public override bool CanConvert(Type objectType)
        {
            return typeof (DateTimeOffset) == objectType;
        }
    }
}