using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RollwayStation.Components.Helpers
{
    public static class CssHelper
    {
        public static string GetCssCalcString(int vw, int vh)
        {
            return $"calc(100% + {vw}vw + {vh}vh);";
        }
    }
}
