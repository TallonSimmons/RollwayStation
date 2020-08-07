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

            var train = new Train(2);

            var auction = new Auction(train, 3);

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
                new Die {Face = 4},
                new Die {Face = 6},
                new Die {Face = 6},
                new Die {Face = 4},
                new Die {Face = 2}
            };

            var train = new Train(2);

            var auction = new Auction(train, 6);

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
