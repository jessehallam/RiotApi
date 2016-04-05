using Newtonsoft.Json;
using RiotApi.Serialization.Json;

namespace RiotApi.Entity.Matches
{
    [JsonConverter(typeof (EnumMappingConverter<EventLaneType>))]
    public enum EventLaneType
    {
        [Mapping("BOT_LANE")] Bottom,
        [Mapping("MID_LANE")] Middle,
        [Mapping("TOP_LANE")] Top
    }
}