using System;

namespace RiotApi
{
    /// <summary>
    /// Contains information relating to retrying failed HTTP requests.
    /// </summary>
    public class RetryPolicy
    {
        /// <summary>
        /// The interval to wait after a failed attempt prior to retrying.
        /// </summary>
        public TimeSpan Interval { get; set; }

        /// <summary>
        /// The maximum number of attempts in total.
        /// </summary>
        public int MaximumAttempts { get; set; }
    }
}