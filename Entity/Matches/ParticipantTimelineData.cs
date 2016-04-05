namespace RiotApi.Entity.Matches
{
    public class ParticipantTimelineData
    {
        /// <summary>
        /// Value per minute from 10:00 to 20:00
        /// </summary>
        public double TenToTwenty { get; set; }

        /// <summary>
        /// Value per minute from 30:00 to end of game.
        /// </summary>
        public double ThirtyToEnd { get; set; }

        /// <summary>
        /// Value per minute from 20:00 to 30:00.
        /// </summary>
        public double TwentyToThirty { get; set; }

        /// <summary>
        /// Value per minute from beginning of game to 10:00.
        /// </summary>
        public double ZeroToTen { get; set; }
    }
}