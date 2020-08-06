using System;
namespace RollwayStation.Models
{
    public class Bid
    {
        public Bid(CompanyType company, int biddingRound)
        {
            Company = company;
            BiddingRound = biddingRound;
        }

        public CompanyType Company { get; }
        public int BiddingRound { get; }
    }
}
