using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using RiotApi.Serialization.Json;

namespace RiotApi.Entity.Matches
{
    public class MatchTimeline
    {
        [JsonConverter(typeof (MillisecondsToTimeConverter))]
        public TimeSpan FrameInterval { get; set; }
        public IList<MatchFrame> Frames { get; set; } 
    }
}