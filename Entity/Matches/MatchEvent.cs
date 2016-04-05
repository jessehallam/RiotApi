using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using RiotApi.Serialization.Json;

namespace RiotApi.Entity.Matches
{
    public class MatchEvent
    {
        public AscendedEventType? AscendedType { get; set; }
        public IList<int> AssistingParticipants { get; set; }
        public BuildingEventType? BuildingType { get; set; }
        public int? CreatorId { get; set; }
        public MatchEventType EventType { get; set; }
        public int? ItemAfter { get; set; }
        public int? ItemBefore { get; set; }
        public int? ItemId { get; set; }
        public int? KillerId { get; set; }
        public EventLaneType? LaneType { get; set; }
        public EventLevelUpType? LevelUpType { get; set; }
        public EventMonsterType? MonsterType { get; set; }
        public int? ParticipantId { get; set; }
        public EventPointType? PointCaptured { get; set; }
        public MatchEventPosition Position { get; set; }
        public int? SkillSlot { get; set; }

        public int? TeamId { get; set; }

        [JsonConverter(typeof (MillisecondsToTimeConverter))]
        public TimeSpan Timestamp { get; set; }

        public EventTowerType? TowerType { get; set; }
        public int? VictimId { get; set; }
        public EventWardType? WardType { get; set; }
    }
}