using System.Collections.Generic;

namespace RiotApi.Entity
{
    public class MasteryPage
    {
        public bool Current { get; set; }
        public int Id { get; set; }
        public IList<Mastery> Masteries { get; set; }
        public string Name { get; set; }
    }
}