using System.Collections.Generic;

namespace RiotApi.Entity.Matches
{
    public class MatchList
    {
        public int EndIndex { get; set; } 
        public IList<MatchReference> Matches { get; set; }
        public int StartIndex { get; set; }
        public int TotalGames { get; set; }
    }
}