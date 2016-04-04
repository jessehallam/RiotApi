using System.Collections.Generic;
using Newtonsoft.Json;

namespace RiotApi.Entity
{
    public class RunePage
    {
        public bool Current { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        [JsonProperty("Slots")]
        public IList<RuneSlot> Runes { get; set; }
    }
}