using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace RiotApi
{
    /// <summary>
    /// An implementation of <see cref="WebRequester"/> in which the
    /// requests are rate limited.
    /// </summary>
    public class RateLimitedWebRequester : WebRequester
    {
        /// <summary>
        /// All the regional endpoints.
        /// </summary>
        private static readonly string[] Regions = { "BR", "EUNE", "EUW", "KR", "LAN", "LAS", "NA", "OCE", "TR", "RU" };

        /// <summary>
        /// The duration of a burst period.
        /// </summary>
        private static readonly TimeSpan BurstDuration = TimeSpan.FromSeconds(10);

        /// <summary>
        /// Contains state about the throttler for a particular region.
        /// </summary>
        private class ThrottleState
        {
            public DateTime BurstPeriodStart = DateTime.MinValue;
            public readonly SemaphoreSlim Lock = new SemaphoreSlim(1, 1);
            public int NumRequests = 0;
        }

        private readonly IDictionary<string, ThrottleState> _statesByRegion; 

        public int RequestsPer10Seconds { get; set; }

        public RateLimitedWebRequester(string key) : base(key)
        {
            _statesByRegion = Regions.ToDictionary(x => x, x => new ThrottleState(), StringComparer.OrdinalIgnoreCase);
        }

        protected override async Task<HttpResponseMessage> ResolveResponseMessage(string region, HttpRequestMessage request, CancellationToken cancellationToken)
        {
            await ThrottleRequest(region, cancellationToken);
            return await base.ResolveResponseMessage(region, request, cancellationToken);
        }

        protected async Task ThrottleRequest(string region, CancellationToken cancellationToken)
        {
            var state = _statesByRegion[region];
            await state.Lock.WaitAsync(cancellationToken);
            try
            {
                var burstPeriodDur = DateTime.Now - state.BurstPeriodStart;

                if (burstPeriodDur > BurstDuration)
                {
                    state.NumRequests = 0;
                    state.BurstPeriodStart = DateTime.Now;
                }

                if (++state.NumRequests > RequestsPer10Seconds)
                {
                    var timeToWait = BurstDuration - burstPeriodDur;
                    await Task.Delay(timeToWait.TotalSeconds < 1 ? TimeSpan.FromSeconds(1) : timeToWait, cancellationToken);
                    state.NumRequests = 1;
                }
            }
            finally
            {
                state.Lock.Release();
            }
        }
    }
}