namespace RiotApi.Entity.Leagues
{
    public class LeagueEntry
    {
        public class MiniSeriesInfo
        {
            public int Losses { get; set; }
            public string Progress { get; set; }
            public int Target { get; set; }
            public int Wins { get; set; }
        }

        public LeagueDivision Division { get; set; }
        public bool IsFreshBlood { get; set; }
        public bool IsHotStreak { get; set; }
        public bool IsInactive { get; set; }
        public bool IsVeteran { get; set; }
        public int LeaguePoints { get; set; }
        public int Losses { get; set; }
        public MiniSeriesInfo MiniSeries { get; set; }
        public string PlayerOrTeamId { get; set; }
        public string PlayerOrTeamName { get; set; }
        public int Wins { get; set; }
    }
}