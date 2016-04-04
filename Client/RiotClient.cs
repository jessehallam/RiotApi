namespace RiotApi.Client
{
    /// <summary>
    /// Provides methods for requesting entities from the Riot API.
    /// </summary>
    public class RiotClient : RiotClientBase
    {
        /// <summary>
        /// Gets the client used for making requests to the summoner API.
        /// </summary>
        public SummonerClient Summoners { get; }


        /// <summary>
        /// Constructs a new instance of <see cref="RiotClient"/>.
        /// </summary>
        public RiotClient(WebRequester requester) : base(requester)
        {
            Summoners = new SummonerClient(requester);
        }
    }
}