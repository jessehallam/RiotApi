using Newtonsoft.Json;
using RiotApi.Serialization.Json;

namespace RiotApi.Entity.Matches
{
    [JsonConverter(typeof (EnumMappingConverter<MatchTier>))]
    public enum MatchTier
    {
        [Mapping("UNRANKED")] Unranked,
        [Mapping("BRONZE")] Bronze,
        [Mapping("SILVER")] Silver,
        [Mapping("GOLD")] Gold,
        [Mapping("PLATINUM")] Platinum,
        [Mapping("DIAMOND")] Diamond,
        [Mapping("MASTER")] Master,
        [Mapping("CHALLENGER")] Challenger
    }
}