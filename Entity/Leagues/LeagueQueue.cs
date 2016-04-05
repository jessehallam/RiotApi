using System.Diagnostics.CodeAnalysis;
using RiotApi.Serialization.Json;

namespace RiotApi.Entity.Leagues
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public enum LeagueQueue
    {
        [Mapping("RANKED_SOLO_5x5")]
        RankedSolo_5v5,
        [Mapping("RANKED_TEAM_3x3")]
        RankedTeam_5v5,
        [Mapping("RANKED_TEAM_5x5")]
        RankedTeam_3v3
    }
}