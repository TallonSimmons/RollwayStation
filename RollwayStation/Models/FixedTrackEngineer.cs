using System;
namespace RollwayStation.Models
{
    public class FixedTrackEngineer : BaseEngineer, IEngineer
    {
        public int Penalty => 15;
    }
}
