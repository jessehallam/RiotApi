using Newtonsoft.Json;
using RiotApi.Serialization.Json;

namespace RiotApi.Entity.Matches
{
    [JsonConverter(typeof (EnumMappingConverter<MatchRole>))]
    public enum MatchRole
    {
        [Mapping("NONE")] None,
        [Mapping("DUO")] Duo,
        [Mapping("SOLO")] Solo,
        [Mapping("DUO_CARRY")] DuoCarry,
        [Mapping("DUO_SUPPORT")] DuoSupport
    }
}