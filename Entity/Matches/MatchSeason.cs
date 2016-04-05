using Newtonsoft.Json;
using RiotApi.Serialization.Json;

namespace RiotApi.Entity.Matches
{
    [JsonConverter(typeof (EnumMappingConverter<MatchSeason>))]
    public enum MatchSeason
    {
        [Mapping("PRESEASON3")] PreSeason3,
        [Mapping("SEASON3")] Season3,
        [Mapping("PRESEASON2014")] PreSeason2014,
        [Mapping("SEASON2014")] Season2014,
        [Mapping("PRESEASON2015")] PreSeason2015,
        [Mapping("SEASON2015")] Season2015,
        [Mapping("PRESEASON2016")] PreSeason2016,
        [Mapping("SEASON2016")] Season2016
    }
}