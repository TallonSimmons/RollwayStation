using System;
namespace RollwayStation.Models
{
    public class BaseEngineer
    {
        public bool AbilityAvailable { get; private set; }

        public void UseAbility()
        {
            if (!AbilityAvailable)
            {
                return;
            }

            AbilityAvailable = false;
        }
    }
}
