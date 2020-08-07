using System.Collections.Generic;

namespace RollwayStation.Models
{
    public class GameLog
    {
        public List<GameRound> GameRounds { get; } = new List<GameRound>();
    }
}
