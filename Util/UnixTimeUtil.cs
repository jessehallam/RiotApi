using System;

namespace RiotApi.Util
{
    internal static class UnixTimeUtil
    {
        private static readonly  DateTimeOffset EpochTime = 
            new DateTimeOffset(1970, 1, 1, 0, 0, 0, TimeSpan.Zero);

        public static DateTimeOffset FromUnixTime(long ms)
        {
            return EpochTime.AddMilliseconds(ms);
        }

        public static long ToUnixTime(DateTimeOffset date)
        {
            TimeSpan dur = date - EpochTime;
            return (long) dur.TotalMilliseconds;
        }
    }
}