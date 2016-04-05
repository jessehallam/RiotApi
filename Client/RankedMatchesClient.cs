using System.Collections.Generic;
using System.Threading;
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

        public Task<MatchDetail> GetMatchDetailAsync(string region, long matchId,
            bool? includeTimeline = false,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var uri = $"{ApiVersions.Match}/match/{matchId}";
            var parameters = includeTimeline.HasValue
                ? new[]
                {
                    new KeyValuePair<string, string>("includeTimeline", includeTimeline.Value.ToString().ToLowerInvariant())
                } : null;
            return Requester.GetAsync<MatchDetail>(region, uri, parameters, cancellationToken);
        }

        public MatchListQuery GetMatchList(string region, int summonerId)
        {
            return new MatchListQuery(Requester, region, summonerId);
        }
    }
}