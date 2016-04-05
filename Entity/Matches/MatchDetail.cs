using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using RiotApi.Serialization.Json;

namespace RiotApi.Entity.Matches
{
    public class MatchDetail
    {
        [JsonProperty("MapId")]
        public MapType Map { get; set; }

        [JsonConverter(typeof (MillisecondsConverter))]
        public DateTimeOffset MatchCreation { get; set; }

        [JsonConverter(typeof (SecondsToTimeConverter))]
        public TimeSpan MatchDuration { get; set; }

        public long MatchId { get; set; }
        public MatchMode MatchMode { get; set; }
        public MatchType MatchType { get; set; }
        public string MatchVersion { get; set; }
        public IList<ParticipantIdentity> ParticipantIdentities { get; set; } 
        public IList<MatchParticipant> Participants { get; set; } 
        public QueueType QueueType { get; set; }
        public string Region { get; set; }
        public MatchSeason Season { get; set; }
        public IList<MatchTeam> Teams { get; set; } 
        public MatchTimeline Timeline { get; set; }
    }
}