using Newtonsoft.Json;

namespace RiotApi.Entity.Matches
{
    public class MatchPlayer
    {
        public string MatchHistoryUri { get; set; }

        [JsonProperty("ProfileIcon")]
        public int ProfileIconId { get; set; }

        public int SummonerId { get; set; }
        public string SummonerName { get; set; }
    }
}