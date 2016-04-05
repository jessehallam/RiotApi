using RiotApi.Serialization.Json;

namespace RiotApi.Entity.Matches
{
    public enum MatchLane
    {
        [Mapping("MID")] Mid = 0,
        [Mapping("MIDDLE")] Middle = 0,
        [Mapping("TOP")] Top = 1,
        [Mapping("JUNGLE")] Jungle = 2,
        [Mapping("BOT")] Bot = 3,
        [Mapping("BOTTOM")] Bottom = 3
    }
}