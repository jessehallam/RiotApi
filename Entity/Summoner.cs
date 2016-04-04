using System;
using Newtonsoft.Json;
using RiotApi.Serialization.Json;

namespace RiotApi.Entity
{
    public class Summoner
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ProfileIconId { get; set; }
        [JsonConverter(typeof (MillisecondsConverter))]
        public DateTimeOffset RevisionDate { get; set; }
        public int SummonerLevel { get; set; }
    }
}