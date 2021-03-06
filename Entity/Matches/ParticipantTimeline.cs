namespace RiotApi.Entity.Matches
{
    public class ParticipantTimeline
    {
        public ParticipantTimelineData AncientGolemAssistPerMinCounts { get; set; }
        public ParticipantTimelineData AncientGolemKillsPerMinCounts { get; set; }
        public ParticipantTimelineData AssistedLaneDeathsPerMinDeltas { get; set; }
        public ParticipantTimelineData AssistedLaneKillsPerMinDeltas { get; set; }
        public ParticipantTimelineData BaronAssistsPerMinCounts { get; set; }
        public ParticipantTimelineData CreepsPerMinDeltas { get; set; }
        public ParticipantTimelineData CsDiffPerMinDeltas { get; set; }
        public ParticipantTimelineData DamageTakenDiffPerMinDeltas { get; set; }
        public ParticipantTimelineData DamageTakenPerMinDeltas { get; set; }
        public ParticipantTimelineData DragonAssistsPerMinCounts { get; set; }
        public ParticipantTimelineData DragonKillsPerMinCounts { get; set; }
        public ParticipantTimelineData ElderLizardAssistsPerMinCounts { get; set; }
        public ParticipantTimelineData ElderLizardKillsPerMinCounts { get; set; }
        public ParticipantTimelineData GoldPerMinDeltas { get; set; }
        public ParticipantTimelineData InhibitorAssistsPerMinCounts { get; set; }
        public ParticipantTimelineData InhibitorKillsPerMinCounts { get; set; }
        public MatchLane Lane { get; set; }
        public MatchRole Role { get; set; }
        public ParticipantTimelineData TowerAssistPerMinCounts { get; set; }
        public ParticipantTimelineData TowerKillsPerMinCounts { get; set; }
        public ParticipantTimelineData TowerKillsPerMinDeltas { get; set; }
        public ParticipantTimelineData VilemawAssistsPerMinCounts { get; set; }
        public ParticipantTimelineData VilemawKillsPerMinCounts { get; set; }
        public ParticipantTimelineData WardsPerMinDeltas { get; set; }
        public ParticipantTimelineData XpDiffPerMinDeltas { get; set; }
        public ParticipantTimelineData XpPerMinDeltas { get; set; }
    }
}