using Newtonsoft.Json;
using RiotApi.Serialization.Json;

namespace RiotApi.Entity.Matches
{
    [JsonConverter(typeof (EnumMappingConverter<EventPointType>))]
    public enum EventPointType
    {
        [Mapping("POINT_A")] A,
        [Mapping("POINT_B")] B,
        [Mapping("POINT_C")] C,
        [Mapping("POINT_D")] D,
        [Mapping("POINT_E")] E
    }
}