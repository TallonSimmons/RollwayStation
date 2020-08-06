using System;
using System.Collections.Generic;
using RollwayStation.Models;

namespace RollwayStation
{
    public class Store
    {
        public readonly List<Die> Dice = new List<Die>
        {
            new Die(),
            new Die(),
            new Die(),
            new Die(),
            new Die(),
        };
    }
}
