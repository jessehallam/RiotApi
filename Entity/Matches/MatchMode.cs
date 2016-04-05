using Newtonsoft.Json;
using RiotApi.Serialization.Json;

namespace RiotApi.Entity.Matches
{
    [JsonConverter(typeof (EnumMappingConverter<MatchMode>))]
    public enum MatchMode
    {
        [Mapping("CLASSIC")] Classic,
        [Mapping("ODIN")] Odin,
        [Mapping("ARAM")] Aram,
        [Mapping("TUTORIAL")] Tutorial,
        [Mapping("ONEFORALL")] OneForAll,
        [Mapping("ASCENSION")] Ascension,
        [Mapping("FIRSTBLOOD")] FirstBlood,
        [Mapping("KINGPORO")] KingPoro
    }
}