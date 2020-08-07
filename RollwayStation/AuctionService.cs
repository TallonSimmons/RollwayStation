using RollwayStation.Models;
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
            return store.Auctions.FirstOrDefault(x => x.AuctionWinner == null);
        }
    }
}
