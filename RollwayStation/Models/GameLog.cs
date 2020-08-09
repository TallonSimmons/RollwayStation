using System.Collections.Generic;

namespace RollwayStation.Models
{
    public class GameLog
    {
        public int CurrentRound => GameRounds?.Count + 1 ?? 0;
        public List<GameRound> GameRounds { get; } = new List<GameRound>();
    }
}
