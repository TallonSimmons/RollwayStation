using System;
namespace RollwayStation.Models
{
    public class Route
    {
        private readonly Train train;
        private int stations;
        private int dots;
        private int triangles;
        private int stars;

        public Route(Train train)
        {
            if(train == null)
            {
                throw new ArgumentOutOfRangeException();
            }

            this.train = train;
        }

        public int Stations
        {
            get => stations;
            set => stations = value >= 0 && StopsLeft >= value ? value : stations;
        }
        public int Dots
        {
            get => dots;
            set => dots = value >= 0 && StopsLeft >= value ? value : dots;
        }
        public int Triangles
        {
            get => triangles;
            set => triangles = value >= 0 && StopsLeft >= value ? value : triangles;
        }
        public int Stars
        {
            get => stars;
            set => stars = value >= 0 && StopsLeft >= value ? value : stars;
        }
        public int StopsLeft => train.NumberOfStopsAllowed - Stations - Dots - Triangles - Stars;
        public bool IsValid => Stations >= 1;

        public int Calculate()
        {
            if(train.OwningCompany == null)
            {
                return 0;
            }

            return (stations + (Dots * 2) + (Triangles * 3) + (Stars * 5)) * train.OwningCompany.Shares;
        }
    }
}
