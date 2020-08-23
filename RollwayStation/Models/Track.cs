using System;
using System.Collections.Generic;
using System.Linq;

namespace RollwayStation.Models
{
    public enum TrackType { Straight, Curve, TightCurve }
    public class Track
    {
        private static readonly Dictionary<List<int>, TrackType> trackMap = new Dictionary<List<int>, TrackType>
        {
            { new List<int>{1,2}, TrackType.Straight },
            { new List<int>{3,4}, TrackType.Curve},
            { new List<int>{5,6}, TrackType.TightCurve },
        };

        public TrackType? Type { get; private set; }

        public void LayTrack(Die die)
        {
            if (die == null)
            {
                throw new ArgumentNullException();
            }

            if (die.Face < 1 || die.Face > 6)
            {
                throw new ArgumentOutOfRangeException();
            }

            Type = trackMap.FirstOrDefault(x => x.Key.Contains(die.Face)).Value;
        }
    }
}
