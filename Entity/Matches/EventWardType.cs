using Newtonsoft.Json;
using RiotApi.Serialization.Json;

namespace RiotApi.Entity.Matches
{
    [JsonConverter(typeof (EnumMappingConverter<EventWardType>))]
    public enum EventWardType
    {
        [Mapping("BLUE_TRINKET")] BlueTrinket,
        [Mapping("SIGHT_WARD")] SightWard,
        [Mapping("TEEMO_MUSHROOM")] TeemoMushroom,
        [Mapping("UNDEFINED")] UndefinedWard,
        [Mapping("VISION_WARD")] VisionWard,
        [Mapping("YELLOW_TRINKET")] YellowTrinket,
        [Mapping("YELLOW_TRINKET_UPGRADE")] YellowTrinketUpgrade
    }
}