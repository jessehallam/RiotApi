using Newtonsoft.Json;
using RiotApi.Serialization.Json;

namespace RiotApi.Entity.Matches
{
    [JsonConverter(typeof (EnumMappingConverter<AscendedEventType>))]
    public enum AscendedEventType
    {
        /// <summary>
        /// Occurs when a participant kills the ascended player.
        /// </summary>
        [Mapping("CLEAR_ASCENDED")] Clear,
        [Mapping("CHAMPION_ASCENDED")] ChampionAscended,
        [Mapping("MINION_ASCENDED")] MinionAscended
    }
}