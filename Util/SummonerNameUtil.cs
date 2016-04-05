namespace RiotApi.Util
{
    internal static class SummonerNameUtil
    {
        public static string Escape(string name)
        {
            return name.Replace(" ", "")
                .ToLowerInvariant();
        }
    }
}