namespace RiotApi.Client
{
    /// <summary>
    /// Provides methods for requesting entities from the Riot API.
    /// </summary>
    public abstract class RiotClientBase
    {
        /// <summary>
        /// Gets the <see cref="WebRequester"/> used by the client to send requests.
        /// </summary>
        public WebRequester Requester { get; private set; }
        
        /// <summary>
        /// Constructs a new instance of <see cref="RiotClientBase"/>.
        /// </summary>
        /// <param name="requester">A web requester.</param>
        protected RiotClientBase(WebRequester requester)
        {
            Requester = requester;
        }
    }
}