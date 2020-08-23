namespace RollwayStation.Models
{
    public class GameRound
    {
        public GameRound(int roundNumber)
        {
            RoundNumber = roundNumber;
        }

        public Auction Auction { get; set; }
        public Share Share { get; set; }
        public Track TrackLaid { get; set; }
        public Die HexDie { get; set; }
        public int RoundNumber { get; }
        public bool Completed => Auction != null && Share != null && HexDie != null;
        public bool IsOperatingRound =>
            RoundNumber == 4
            || RoundNumber == 7
            || RoundNumber == 10
            || RoundNumber == 15;
    }
}
