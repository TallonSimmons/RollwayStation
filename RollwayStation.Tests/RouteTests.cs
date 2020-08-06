using RollwayStation.Models;
using Xunit;

namespace RollwayStation.Tests
{
    public class RouteTests
    {
        [Fact]
        public void RouteShouldCalculateProperly()
        {
            var train = new Train(6)
            {
                OwningCompany = new Company(CompanyType.SquareRail) { Shares = 3 }
            };
            var route = new Route(train) { Dots = 3, Stars = 1, Stations = 1, Triangles = 1 };
            var expected = 45;
            var actual = route.Calculate();

            Assert.Equal(expected, actual);
        }
    }
}
