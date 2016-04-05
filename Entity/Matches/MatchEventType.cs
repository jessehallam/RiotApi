using Newtonsoft.Json;
using RiotApi.Serialization.Json;

namespace RiotApi.Entity.Matches
{
    [JsonConverter(typeof (EnumMappingConverter<MatchEventType>))]
    public enum MatchEventType
    {
        [Mapping("ASCENDED_EVENT")] AscendedEvent,
        [Mapping("BUILDING_KILL")] BuildingKilled,
        [Mapping("CAPTURE_POINT")] CapturedPoint,
        [Mapping("CHAMPION_KILL")] ChampionKilled,
        [Mapping("ELITE_MONSTER_KILL")] EliteMonsterKilled,
        [Mapping("ITEM_DESTROYED")] ItemDestroyed,
        [Mapping("ITEM_PURCHASED")] ItemPurchased,
        [Mapping("ITEM_SOLD")] ItemSold,
        [Mapping("ITEM_UNDO")] ItemUndo,
        [Mapping("PORO_KING_SUMMON")] PoroKingSummoned,
        [Mapping("SKILL_LEVEL_UP")] SkillLeveledUp,
        [Mapping("WARD_KILL")] WardKilled,
        [Mapping(("WARD_PLACED"))] WardPlaced
    }
}