using Newtonsoft.Json;
using RiotApi.Serialization.Json;

namespace RiotApi.Entity.Matches
{
    [JsonConverter(typeof (EnumMappingConverter<EventLevelUpType>))]
    public enum EventLevelUpType
    {
         [Mapping("NORMAL")] Normal,
         [Mapping("EVOLVE")] Evolve
    }
}