using Newtonsoft.Json;
using RiotApi.Serialization.Json;

namespace RiotApi.Entity.Matches
{
    [JsonConverter(typeof (MapTypeConverter))]
    public enum MapType
    {
        SummonersRift = 11,
        TheProvingGrounds = 3,
        TwistedTreeline = 10,
        TheCrystalScar = 8,
        HowlingAbyss = 12,
        ButchersBridge = 14
    }
}