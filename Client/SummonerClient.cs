using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using RiotApi.Entity;

namespace RiotApi.Client
{
    public class SummonerClient : RiotClientBase
    {
        public SummonerClient(WebRequester requester) : base(requester)
        {
            
        }

        /// <summary>
        /// Find a summoner by its id.
        /// </summary>
        /// <param name="region">The region.</param>
        /// <param name="id">The summoner id.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A summoner object.</returns>
        public async Task<Summoner> FindAsync(string region, int id,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var uri = $"{ApiVersions.Summoner}/summoner/{id}";
            var result = await Requester.GetAsync<IDictionary<int, Summoner>>(region, uri, null, cancellationToken);
            return result != null && result.ContainsKey(id) ? result[id] : null;
        }

        /// <summary>
        /// Find multiple summoners by their ids.
        /// </summary>
        /// <param name="region">The region.</param>
        /// <param name="ids">The ids.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A dictionary where the keys are summoner ids and values are summoner objects.</returns>
        /// <remarks>
        /// Including multiple summoner ids in the <paramref name="ids"/> parameter does not guarantee that
        /// the response object will contain every key. If a summoner does not exist, that id will not be
        /// included in the dictionary.
        /// </remarks>
        public async Task<IDictionary<int, Summoner>> FindAsync(string region, IEnumerable<int> ids,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var uri = $"{ApiVersions.Summoner}/summoner/{string.Join(",", ids)}";
            var result = await Requester.GetAsync<IDictionary<int, Summoner>>(region, uri, null, cancellationToken);
            return result;
        } 

        /// <summary>
        /// Find a summoner by its name.
        /// </summary>
        /// <param name="region">The region.</param>
        /// <param name="name">The summoner name.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A summoner object.</returns>
        public async Task<Summoner> FindByNameAsync(string region, string name,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var uri = $"{ApiVersions.Summoner}/summoner/by-name/{Uri.EscapeDataString(name)}";
            var result = await Requester.GetAsync<IDictionary<string, Summoner>>(region, uri, null, cancellationToken);
            return result != null && result.ContainsKey(name) ? result[name] : null;
        }

        /// <summary>
        /// Gets the mastery pages for a summoner.
        /// </summary>
        /// <param name="region">The region.</param>
        /// <param name="summonerId">The summoner id.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A mastery collection.</returns>
        public async Task<MasteryPageCollection> GetMasteries(string region, int summonerId,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var uri = $"{ApiVersions.Summoner}/summoner/{summonerId}/masteries";
            var result =
                await Requester.GetAsync<IDictionary<int, MasteryPageCollection>>(region, uri, null, cancellationToken);
            return result != null && result.ContainsKey(summonerId) ? result[summonerId] : null;
        }

        /// <summary>
        /// Gets the rune pages for a summoner.
        /// </summary>
        /// <param name="region">The region.</param>
        /// <param name="summonerId">The summoner id.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A rune page collection.</returns>
        public async Task<RunePageCollection> GetRunes(string region, int summonerId,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var uri = $"{ApiVersions.Summoner}/summoner/{summonerId}/runes";
            var result = await Requester.GetAsync<IDictionary<int, RunePageCollection>>(region,
                uri, null, cancellationToken);
            return result != null && result.ContainsKey(summonerId) ? result[summonerId] : null;
        } 
    }
}