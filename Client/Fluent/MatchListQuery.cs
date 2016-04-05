using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using RiotApi.Entity.Matches;
using RiotApi.Serialization.Json;
using RiotApi.Util;

namespace RiotApi.Client.Fluent
{
    public class MatchListQuery
    {
        private readonly WebRequester _requester;
        private readonly string _region;
        private readonly int _summonerId;

        private bool _isComplete = false;
        private Task<MatchList> _task = null; 

        private int? _startIndex;
        private int? _endIndex;
        private DateTimeOffset? _startTime;
        private DateTimeOffset? _endTime;
        private int[] _champions;
        private MatchQueue[] _queues;
        private MatchSeason[] _seasons;

        public Task<MatchList> MatchList => _isComplete ? _task : null;

        internal MatchListQuery(WebRequester requester, string region, int summonerId)
        {
            _requester = requester;
            _region = region;
            _summonerId = summonerId;
        }

        public MatchListQuery Between(int? startIndex, int? endIndex)
        {
            _startIndex = startIndex;
            _endIndex = endIndex;
            return this;
        }

        public MatchListQuery Between(DateTime? startTime, DateTime? endTime)
        {
            _startTime = startTime.HasValue ? new DateTimeOffset?(startTime.Value) : null;
            _endTime = endTime.HasValue ? new DateTimeOffset?(endTime.Value) : null;
            return this;
        }

        public MatchListQuery Between(DateTimeOffset? startTime, DateTimeOffset? endTime)
        {
            _startTime = startTime;
            _endTime = endTime;
            return this;
        }

        public MatchListQuery WithChampions(params int[] championIds)
        {
            _champions = championIds;
            return this;
        }

        public MatchListQuery WithQueues(params MatchQueue[] rankedQueues)
        {
            _queues = rankedQueues;
            return this;
        }

        public MatchListQuery WithSeasons(params MatchSeason[] seasons)
        {
            _seasons = seasons;
            return this;
        }

        public Task<MatchList> Evaluate(CancellationToken cancellationToken = default(CancellationToken))
        {
            return GenerateTask(cancellationToken);
        } 

        private Task<MatchList> GenerateTask(CancellationToken cancellationToken = default(CancellationToken))
        {
            var parameters = new Dictionary<string, string>();

            if (_startIndex.HasValue)
                parameters.Add("beginIndex", _startIndex.Value.ToString());

            if (_endIndex.HasValue)
                parameters.Add("endIndex", _endIndex.Value.ToString());

            if (_startTime.HasValue)
                parameters.Add("beginTime", UnixTimeUtil.ToUnixTime(_startTime.Value).ToString());

            if (_endTime.HasValue)
                parameters.Add("endTime", UnixTimeUtil.ToUnixTime(_endTime.Value).ToString());

            if (_champions != null)
                parameters.Add("championIds", string.Join(",", _champions));

            if (_queues != null)
            {
                var mapper = EnumMappingRegistry.GetMapper<MatchQueue>();
                var values = from q in _queues select mapper.GetKey(q);
                parameters.Add("rankedQueues", string.Join(",", values));
            }

            if (_seasons != null)
            {
                var mapper = EnumMappingRegistry.GetMapper<MatchSeason>();
                var values = from s in _seasons select mapper.GetKey(s);
                parameters.Add("seasons", string.Join(",", values));
            }

            var uri = $"{ApiVersions.MatchList}/matchlist/by-summoner/{_summonerId}";
            return _requester.GetAsync<MatchList>(_region, uri, parameters);
        } 
    }
}