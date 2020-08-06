using System;
using System.Collections.Generic;
using System.Linq;

namespace RollwayStation.Models
{
    public enum TrackType { Straight, Curve, TightCurve }
    public class Track
    {
        public static readonly Dictionary<List<int>, TrackType> trackMap = new Dictionary<List<int>, TrackType>
        {
            { new List<int>{1,2}, TrackType.Straight },
            { new List<int>{3,4}, TrackType.Straight},
            { new List<int>{5,6}, TrackType.Straight },
        };

        public TrackType LayTrack(Die die)
        {
            return trackMap.FirstOrDefault(x => x.Key.Contains(die.Face)).Value;
        }
    }
}
