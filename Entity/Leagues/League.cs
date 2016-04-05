using System.Collections.Generic;
using Newtonsoft.Json;
using RiotApi.Serialization.Json;

namespace RiotApi.Entity.Leagues
{
    public class League
    {
        public IList<LeagueEntry> Entries { get; set; } 
        public string Name { get; set; }
        public string ParticipantId { get; set; }

        [JsonConverter(typeof (EnumMappingConverter<LeagueQueue>))]
        public LeagueQueue Queue { get; set; }
        
        public LeagueTier Tier { get; set; }
    }
}