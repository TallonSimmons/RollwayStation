using RollwayStation.Models;
using System.Collections.Generic;
using Xunit;

namespace RollwayStation.Tests
{
    public class AuctionTests
    {
        [Fact]
        public void AuctionShouldResolveProperly()
        {
            var dice = new List<Die>
            {
                new Die {Face = 2},
                new Die {Face = 2},
                new Die {Face = 6},
            };

            var train = new Train(3);

            var auction = new Auction(train, new List<int> { 2, 3, 4 });

            foreach (var die in dice)
            {
                auction.PlaceBid(die);
            }


            var expected = CompanyType.SquareRail;
            var actual = auction.AuctionWinner;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TiedAuctionShouldResolveProperly()
        {
            var dice = new List<Die>
            {
                new Die {Face = 2},
                new Die {Face = 6},
                new Die {Face = 6},
                new Die {Face = 2},
                new Die {Face = 4},
            };

            var train = new Train(6);

            var auction = new Auction(train, new List<int> { 11, 12, 13, 14, 15 });

            foreach (var die in dice)
            {
                auction.PlaceBid(die);
            }


            var expected = CompanyType.SquareRail;
            var actual = auction.AuctionWinner;

            Assert.Equal(expected, actual);
        }
    }
}
