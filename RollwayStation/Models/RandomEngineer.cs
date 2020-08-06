using System;
namespace RollwayStation.Models
{
    public class RandomDieRollEngineer : IEngineer
    {
        private readonly int maximumUses = 3;
        private int timesUsed;
        public bool AbilityAvailable => timesUsed < maximumUses;
        public int Penalty => timesUsed * 5;

        public void UseAbility()
        {
            if(timesUsed == maximumUses)
            {
                return;
            }

            timesUsed++;
        }
    }
}
