using System.Collections.Generic;

namespace RiotApi.Entity.Leagues
{
    public class League
    {
        public IList<LeagueEntry> Entries { get; set; } 
        public string Name { get; set; }
        public string ParticipantId { get; set; }
        public LeagueQueue Queue { get; set; }
        public LeagueTier Tier { get; set; }
    }
}