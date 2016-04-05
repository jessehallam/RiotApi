using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using RiotApi.Entity.Leagues;
using RiotApi.Serialization.Json;

namespace RiotApi.Client
{
    public class LeagueClient : RiotClientBase
    {
        private readonly EnumMapper<LeagueQueue> _mapper; 

        public LeagueClient(WebRequester requester) : base(requester)
        {
            _mapper = EnumMappingRegistry.GetMapper<LeagueQueue>();
        }

        public Task<League> GetChallengerLeagueAsync(string region, LeagueQueue queue,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var uri = $"{ApiVersions.League}/league/challenger";
            
            var paramList = new[]
            {
                new KeyValuePair<string, string>("type", _mapper.GetKey(queue)) 
            };
            return Requester.GetAsync<League>(region, uri, paramList, cancellationToken);
        }

        /// <summary>
        /// Gets the leagues for a summoner.
        /// </summary>
        /// <param name="region">The region.</param>
        /// <param name="summonerId">The summoner id.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A list of leagues.</returns>
        public async Task<IList<League>> GetLeaguesAsync(string region, int summonerId,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var uri = $"{ApiVersions.League}/league/by-summoner/{summonerId}";
            var result = await Requester.GetAsync<IDictionary<int, IList<League>>>(region,
                uri, null, cancellationToken);

            return result != null && result.ContainsKey(summonerId) ? result[summonerId] : null;
        }

        /// <summary>
        /// Gets all league entriesfor a summoner.
        /// </summary>
        /// <param name="region">The region.</param>
        /// <param name="summonerId">The summoner id.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A list of leagues.</returns>
        public async Task<IList<League>> GetLeagueEntriesAsync(string region, int summonerId,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var uri = $"{ApiVersions.League}/league/by-summoner/{summonerId}/entry";
            var result = await Requester.GetAsync<IDictionary<int, IList<League>>>(region,
                uri, null, cancellationToken);

            return result != null && result.ContainsKey(summonerId) ? result[summonerId] : null;
        }

        public Task<League> GetMasterLeagueAsync(string region, LeagueQueue queue,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var uri = $"{ApiVersions.League}/league/master";
            var paramList = new[]
            {
                new KeyValuePair<string, string>("type", _mapper.GetKey(queue))
            };
            return Requester.GetAsync<League>(region, uri, paramList, cancellationToken);
        } 
    }
}