using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json;
using RiotApi.Serialization.Json;

namespace RiotApi.Entity.Matches
{
    [JsonConverter(typeof (EnumMappingConverter<QueueType>))]
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public enum QueueType
    {
        [Mapping("CUSTOM")] Custom,
        [Mapping("NORMAL_3x3")] Normal_3v3,
        [Mapping("NORMAL_5x5_BLIND")] Normal_5v5_Blind,
        [Mapping("NORMAL_5x5_DRAFT")] Normal_5v5_Draft,
        [Mapping("RANKED_SOLO_5x5")] Ranked_Solo_5v5,
        [Mapping("RANKED_TEAM_3x3")] Ranked_Team_3v3,
        [Mapping("RANKED_TEAM_5x5")] Ranked_Team_5v5,
        [Mapping("RANKED_PREMADE_5x5")] Ranked_Premade_5v5,
        [Mapping("RANKED_PREMADE_3x3")] Ranked_Premade_3v3,
        [Mapping("ODIN_5x5_BLIND")] Odin_5v5_Blind,
        [Mapping("ODIN_5x5_DRAFT")] Odin_5v5_Draft,
        [Mapping("BOT_5x5")] Bot_5v5,
        [Mapping("BOT_ODIN_5x5")] Bot_Odin_5v5,
        [Mapping("BOT_5x5_INTRO")] Bot_5v5_Intro,
        [Mapping("BOT_5x5_BEGINNER")] Bot_5v5_Beginner,
        [Mapping("BOT_5x5_INTERMEDIATE")] Bot_5v5_Intermediate,
        [Mapping("BOT_TT_3x3")] Bot_TT_3v3,
        [Mapping("GROUP_FINDER_5x5")] GroupFinder_5v5,
        [Mapping("ARAM_5x5")] Aram_5v5,
        [Mapping("ONEFORALL_5x5")] OneForAll_5v5,
        [Mapping("FIRSTBLOOD_1x1")] FirstBlood_1v1,
        [Mapping("FIRSTBLOOD_2x2")] FirstBlood_2v2,
        [Mapping("SR_6x6")] Hexakill_6v6,
        [Mapping("URF_5x5")] Urf_5v5,
        [Mapping("BOT_URF_5x5")] Urf_Bot_5v5,
        [Mapping("NIGHTMARE_BOT_5x5_RANK1")] Nightmare_Bot_5v5_Rank1,
        [Mapping("NIGHTMARE_BOT_5x5_RANK2")] Nightmare_Bot_5v5_Rank2,
        [Mapping("NIGHTMARE_BOT_5x5_RANK5")] Nightmare_Bot_5v5_Rank5,
        [Mapping("ASCENSION_5x5")] Ascension_5v5,
        [Mapping("HEXAKILL")] Hexakill_TT_6v6,
        [Mapping("BILGEWATER_ARAM_5x5")] Bilgewater_Aram_5v5,
        [Mapping("KING_PORO_5x5")] KingPoro_5v5,
        [Mapping("COUNTER_PICK")] Nemesis_5v5,
        [Mapping("BILGEWATER_5x5")] BlackMarketBrawlers_5v5,
        [Mapping("TEAM_BUILDER_DRAFT_UNRANKED_5x5")] TeamBuilderDraft_Unranked_5v5,
        [Mapping("TEAM_BUILDER_DRAFT_RANKED_5x5")] TeamBuilderDraft_Ranked_5v5
    }
}