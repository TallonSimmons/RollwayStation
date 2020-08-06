using System;
namespace RollwayStation.Models
{
    public interface IEngineer
    {
        int Penalty { get; }
        void UseAbility();
        bool AbilityAvailable { get; }
    }
}
