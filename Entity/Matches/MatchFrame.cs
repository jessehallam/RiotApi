using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using RiotApi.Serialization.Json;

namespace RiotApi.Entity.Matches
{
    public class MatchFrame
    {
        public IList<MatchEvent> Events { get; set; }
        public IDictionary<int, ParticipantFrame> ParticipantFrames { get; set; }

        [JsonConverter(typeof (MillisecondsToTimeConverter))]
        public TimeSpan Timestamp { get; set; }
    }
}