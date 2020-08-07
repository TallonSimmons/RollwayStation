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
            new Auction(new Train(2), 1),
            new Auction(new Train(3), 3),
            new Auction(new Train(4), 3),
            new Auction(new Train(5), 3),
            new Auction(new Train(6), 6),
        };

        public readonly List<Company> Companies = new List<Company>
        {
            new Company(CompanyType.SquareRail),
            new Company(CompanyType.CircleLine),
            new Company(CompanyType.PentagonExpress),
        };
    }
}
