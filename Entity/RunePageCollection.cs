using System.Collections.Generic;

namespace RiotApi.Entity
{
    public class RunePageCollection
    {
        public IList<RunePage> Pages { get; set; }
        public int SummonerId { get; set; }
    }
}