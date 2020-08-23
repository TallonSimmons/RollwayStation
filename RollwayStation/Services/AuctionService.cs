using RollwayStation.Models;
using System.Collections.Generic;
using System.Linq;

namespace RollwayStation
{
    public class AuctionService
    {
        private readonly Store store;

        public AuctionService(Store store)
        {
            this.store = store;
        }

        public Auction GetCurrentAuction()
        {
            return store.Auctions.FirstOrDefault(x => x.BiddingRounds.Contains(store.Round));
        }

        public List<Auction> GetAuctions()
        {
            return store.Auctions;
        }

        public void PlaceBid(Die die)
        {
            var auction = GetCurrentAuction();
            auction.PlaceBid(die);
            store.CurrentRound.Auction = auction;
        }

        public void WithdrawBid()
        {
            GetCurrentAuction().WithdrawBid();
            store.CurrentRound.Auction = null;
        }
    }
}
