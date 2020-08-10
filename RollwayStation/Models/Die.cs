using System;
namespace RollwayStation.Models
{
    public enum AllocationType { Share, Bid, Track, Hex }

    public class Die
    {
        private static readonly Random random = new Random();
        public Die()
        {
            Id = Guid.NewGuid();
        }

        private int face;
        public int Face
        {
            get => face;
            set => face = value >= 1 && value <= 6 ? value : throw new ArgumentOutOfRangeException();
        }
        public Guid Id { get; }
        public AllocationType? AllocatedTo { get; set; }
        public bool Used => AllocatedTo != null;

        public void Roll()
        {
            Face = random.Next(1, 6);
        }
    }
}
