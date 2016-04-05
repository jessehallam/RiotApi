using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json;
using RiotApi.Serialization.Json;

namespace RiotApi.Entity.Matches
{
    [JsonConverter(typeof (EnumMappingConverter<MatchQueue>))]
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public enum MatchQueue
    {
        [Mapping("TEAM_BUILDER_DRAFT_RANKED_5x5")] TeamBuilderDraftRanked_5v5,
        [Mapping("RANKED_SOLO_5x5")] RankedSolo_5v5,
        [Mapping("RANKED_TEAM_3x3")] RankedTeam_3v3,
        [Mapping("RANKED_TEAM_5x5")] RankedTeam_5v5
    }
}