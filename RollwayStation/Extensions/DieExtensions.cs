using RollwayStation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RollwayStation.Extensions
{
    public static class DieExtensions
    {
        public static Die Copy(this Die die)
        {
            return new Die { AllocatedTo = die.AllocatedTo, Face = die.Face, Id = die.Id };
        }
    }
}
