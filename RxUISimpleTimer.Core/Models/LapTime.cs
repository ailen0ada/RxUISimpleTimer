using System;

namespace RxUISimpleTimer.Core.Models
{
    public class LapTime
    {
        public LapTime(TimeSpan elapsed, TimeSpan duration)
        {
            Duration = duration;
            Elapsed = elapsed;
        }

        public TimeSpan Elapsed { get; }

        public TimeSpan Duration { get; }
    }
}
