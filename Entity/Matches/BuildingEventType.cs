using Newtonsoft.Json;
using RiotApi.Serialization.Json;

namespace RiotApi.Entity.Matches
{
    [JsonConverter(typeof (EnumMappingConverter<BuildingEventType>))]
    public enum BuildingEventType
    {
        [Mapping("INHIBITOR_BUILDING")] Inhibitor,
        [Mapping("TOWER_BUILDING")] Tower
    }
}