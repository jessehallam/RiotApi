using Newtonsoft.Json;
using RiotApi.Serialization.Json;

namespace RiotApi.Entity.Matches
{
    [JsonConverter(typeof (EnumMappingConverter<EventMonsterType>))]
    public enum EventMonsterType
    {
        [Mapping("BARON_NASHOR")] Baron,
        [Mapping("BLUE_GOLEM")] BlueGolem,
        [Mapping("DRAGON")] Dragon,
        [Mapping("RED_LIZARD")] RedLizard,
        [Mapping("RIFTHERALD")] RiftHerald,
        [Mapping("VILEMAW")] Vilemaw
    }
}