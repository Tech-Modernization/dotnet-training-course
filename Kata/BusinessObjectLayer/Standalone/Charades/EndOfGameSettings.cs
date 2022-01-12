using System;

namespace BusinessObjectLayer.Charades
{
    public class EndOfGameSettings
    {
        public bool EndOnTimerExpired;
        public bool EndOnBestOfLimitReached;
        public int MaxGames;
        public TimeSpan MaxDuration;
    }
}