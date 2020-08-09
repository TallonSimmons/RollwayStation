using System;
using System.Linq;
using System.Collections.Generic;

namespace RollwayStation.Models
{
    public class Auction
    {
        private int currentBids;
        private readonly Dictionary<List<int>, CompanyType> bidMap = new Dictionary<List<int>, CompanyType>
        {
            { new List<int>{1,2}, CompanyType.SquareRail },
            { new List<int>{3,4}, CompanyType.CircleLine },
            { new List<int>{5,6}, CompanyType.PentagonExpress },
        };

        public Auction(Train train, List<int> biddingRounds)
        {
            Train = train;
            BiddingRounds = biddingRounds;
        }

        public Train Train { get; }
        public List<int> BiddingRounds { get; }
        public int MaxBids => BiddingRounds.Count;
        public CompanyType? AuctionWinner
        {
            get
            {
                if (!Bids.Any())
                {
                    return null;
                }

                var bidsByCompany = new Dictionary<CompanyType, int>
                {
                    { CompanyType.SquareRail, Bids.Where(x => x.Company == CompanyType.SquareRail).Count() },
                    { CompanyType.CircleLine, Bids.Where(x => x.Company == CompanyType.CircleLine).Count() },
                    { CompanyType.PentagonExpress, Bids.Where(x => x.Company == CompanyType.PentagonExpress).Count() },
                }.OrderByDescending(x => x.Value);

                var highestBidder = bidsByCompany.FirstOrDefault();
                var tiedBidders = bidsByCompany.Where(x => x.Key != highestBidder.Key && x.Value == highestBidder.Value);
                var winner = highestBidder;

                for (int i = MaxBids; i > 0; i--)
                {
                    var bidder = Bids.FirstOrDefault(x => x.BiddingRound == i);
                    if (bidder.Company == highestBidder.Key || tiedBidders.Any(x => x.Key == bidder.Company))
                    {
                        return bidder.Company;
                    }
                }

                return null;
            }
        }

        public List<Bid> Bids { get; set; } = new List<Bid>();

        public void PlaceBid(Die die)
        {
            if (currentBids == MaxBids || die == null)
            {
                return;
            }

            var company = bidMap.FirstOrDefault(x => x.Key.Contains(die.Face)).Value;

            Bids.Add(new Bid(company, currentBids + 1));
            currentBids++;
        }

        public void WithdrawBid()
        {
            if (currentBids == 0 || !Bids.Any())
            {
                return;
            }

            Bids.Remove(Bids.LastOrDefault());
            currentBids--;
        }
    }
}
