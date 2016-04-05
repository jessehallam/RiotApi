using Newtonsoft.Json;
using RiotApi.Serialization.Json;

namespace RiotApi.Entity.Matches
{
    [JsonConverter(typeof (EnumMappingConverter<EventTowerType>))]
    public enum EventTowerType
    {
        [Mapping("BASE_TURRET")] Base,
        [Mapping("FOUNTAIN_TURRET")] Fountain,
        [Mapping("INNER_TURRET")] Inner,
        [Mapping("NEXUS_TURRET")] Nexus,
        [Mapping("OUTER_TURRET")] Outer,
        [Mapping("UNDEFINED_TURRET")] UndefinedTurret
    }
}