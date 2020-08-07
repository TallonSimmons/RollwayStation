namespace RollwayStation.Models
{
    public class GameRound
    {
        public GameRound(Auction auction, Company purchasedSharesIn, Track trackLaid, Die hexDie, int roundNumber)
        {
            Auction = auction;
            PurchasedSharesIn = purchasedSharesIn;
            TrackLaid = trackLaid;
            HexDie = hexDie;
            RoundNumber = roundNumber;
        }

        public Auction Auction { get; }
        public Company PurchasedSharesIn { get; }
        public Track TrackLaid { get; }
        public Die HexDie { get; }
        public int RoundNumber { get; }
        public bool IsOperatingRound => RoundNumber == 4 || RoundNumber == 7 || RoundNumber == 10 || RoundNumber == 15;
    }
}
