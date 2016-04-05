using System.Collections.Generic;

namespace RiotApi.Entity.Matches
{
    public class MatchParticipant
    {
        public int ChampionId { get; set; }
        public MatchTier HighestAchievedSeasonTier { get; set; }
        public IList<Mastery> Masteries { get; set; } 
        public int ParticipantId { get; set; }
        public IList<Rune> Runes { get; set; } 
        public int Spell1Id { get; set; }
        public int Spell2Id { get; set; }
        public MatchParticipantStats Stats { get; set; }
        public int TeamId { get; set; }
        public ParticipantTimeline Timeline { get; set; }
    }
}