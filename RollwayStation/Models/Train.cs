using System;
namespace RollwayStation.Models
{
    public class Train
    {
        public Train(int numberOfStopsAllowed)
        {
            NumberOfStopsAllowed = numberOfStopsAllowed;
        }

        public Company OwningCompany { get; set; }
        public int NumberOfStopsAllowed { get; }
    }
}
