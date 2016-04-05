using System;
using Newtonsoft.Json;
using RiotApi.Serialization.Json;

namespace RiotApi.Entity.Matches
{
    public class MatchReference
    {
        [JsonProperty("Champion")]
        public int ChampionId { get; set; }
        public MatchLane Lane { get; set; }
        public long MatchId { get; set; }
        public string PlatformId { get; set; }
        public MatchQueue Queue { get; set; }
        public string Region { get; set; }
        public MatchRole Role { get; set; }
        public MatchSeason Season { get; set; }
        [JsonConverter(typeof (MillisecondsConverter))]
        public DateTimeOffset Timestamp { get; set; }
    }
}