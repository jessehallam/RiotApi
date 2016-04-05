using Newtonsoft.Json;
using RiotApi.Serialization.Json;

namespace RiotApi.Entity.Matches
{
    [JsonConverter(typeof (EnumMappingConverter<MatchType>))]
    public enum MatchType
    {
        [Mapping("CUSTOM_GAME")] Custom,
        [Mapping("MATCHED_GAME")] Matched,
        [Mapping("TUTORIAL_GAME")] Tutorial
    }
}