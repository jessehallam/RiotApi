using System.Collections.Generic;

namespace RiotApi.Entity
{
    public class MasteryPageCollection
    {
        public IList<MasteryPage> Pages { get; set; }
        public int SummonerId { get; set; }
    }
}