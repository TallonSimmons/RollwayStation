using System;
namespace RollwayStation.Models
{
    public class ModifierEngineer : BaseEngineer, IEngineer
    {
        public int Penalty => 10;
    }
}
