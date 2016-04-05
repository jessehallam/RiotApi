namespace RiotApi.Entity.Matches
{
    public class ParticipantIdentity
    {
        public int ParticipantId { get; set; }
        public MatchPlayer Player { get; set; }
    }
}