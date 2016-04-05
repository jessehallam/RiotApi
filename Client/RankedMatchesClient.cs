using System.Threading.Tasks;
using RiotApi.Client.Fluent;
using RiotApi.Entity.Matches;

namespace RiotApi.Client
{
    public class RankedMatchesClient : RiotClientBase
    {
        public RankedMatchesClient(WebRequester requester) : base(requester)
        {
            
        }

        public MatchListQuery GetMatchList(string region, int summonerId)
        {
            return new MatchListQuery(Requester, region, summonerId);
        }
    }
}