using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using RiotApi.Serialization.Json;

namespace RiotApi.Entity.Matches
{
    [JsonConverter(typeof (ParticipantStatsConverter))]
    public class MatchParticipantStats
    {
        public int Assists { get; set; }

        [JsonProperty("ChampLevel")]
        public int ChampionLevel { get; set; }

        public int CombatPlayerScore { get; set; }
        public int Deaths { get; set; }
        public int DoubleKills { get; set; }
        public bool FirstBloodAssist { get; set; }
        public bool FirstBloodKill { get; set; }
        public bool FirstInhibitorAssist { get; set; }
        public bool FirstInhibitorKill { get; set; }
        public bool FirstTowerAssist { get; set; }
        public bool FirstTowerKill { get; set; }
        public int GoldEarned { get; set; }
        public int GoldSpent { get; set; }
        public int InhibitorKills { get; set; }
        public IList<int> Items { get; set; } 
        public int KillingSprees { get; set; }
        public int Kills { get; set; }
        public int LargestCriticalStike { get; set; }
        public int LargestKillingSpree { get; set; }
        public int LargestMultiKill { get; set; }
        public int MagicDamageDealt { get; set; }
        public int MagicDamageDealtToChampions { get; set; }
        public int MagicDamageTaken { get; set; }
        public int MinionsKilled { get; set; }
        public int NeutralMinionsKilled { get; set; }
        public int NeutralMinionsKilledEnemyJungle { get; set; }
        public int NeutralMinionsKilledTeamJungle { get; set; }
        public int NodeCapture { get; set; }
        public int NodeCaptureAssist { get; set; }
        public int NodeNeutralize { get; set; }
        public int NodeNeutralizeAssist { get; set; }
        public int ObjectivePlayerScore { get; set; }
        public int PentaKills { get; set; }
        public int PhysicalDamageDealt { get; set; }
        public int PhysicalDamageDealtToChampions { get; set; }
        public int PhysicalDamageTaken { get; set; }
        public int QuadraKills { get; set; }
        public int SightWardsBoughtInGame { get; set; }
        public int TeamObjective { get; set; }
        public int TotalDamageDealt { get; set; }
        public int TotalDamageDealtToChampions { get; set; }
        public int TotalDamageTaken { get; set; }
        public int TotalHeal { get; set; }
        public int TotalPlayerScore { get; set; }
        public int TotalScoreRank { get; set; }
        [JsonConverter(typeof (SecondsToTimeConverter))]
        public TimeSpan TotalTimeCrowdControlDealt { get; set; }
        public int TotalUnitsHealed { get; set; }
        public int TowerKills { get; set; }
        public int TripleKills { get; set; }
        public int TrueDamageDealt { get; set; }
        public int TrueDamageDealtToChampions { get; set; }
        public int TrueDamageTaken { get; set; }
        public int UnrealKills { get; set; }
        public int VisionWardsBoughtInGame { get; set; }
        public int WardsKilled { get; set; }
        public int WardsPlaced { get; set; }
        public bool Winner { get; set; }
    }
}