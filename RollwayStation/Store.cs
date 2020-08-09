using System;
using System.Collections.Generic;
using RollwayStation.Models;

namespace RollwayStation
{
    public class Store
    {
        public readonly List<Die> Dice = new List<Die>
        {
            new Die(),
            new Die(),
            new Die(),
            new Die(),
            new Die(),
        };

        public readonly List<Auction> Auctions = new List<Auction>
        {
            new Auction(new Train(2), new List<int>{ 1 }),
            new Auction(new Train(3), new List<int>{ 2,3,4 }),
            new Auction(new Train(4), new List<int>{ 5,6,7 }),
            new Auction(new Train(5), new List<int>{ 8,9,10 }),
            new Auction(new Train(6), new List<int>{ 11,12,13,14,15 }),
        };

        public readonly List<Company> Companies = new List<Company>
        {
            new Company(CompanyType.SquareRail),
            new Company(CompanyType.CircleLine),
            new Company(CompanyType.PentagonExpress),
        };

        public int BiddingRound { get; set; } = 1;
    }
}
