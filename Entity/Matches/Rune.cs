using Newtonsoft.Json;

namespace RiotApi.Entity.Matches
{
    public class Rune
    {
        [JsonProperty("Rank")]
        public int Count { get; set; }
        public int RuneId { get; set; }
    }
}