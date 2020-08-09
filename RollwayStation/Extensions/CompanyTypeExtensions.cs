using RollwayStation.Models;
using System;

namespace RollwayStation.Extensions
{
    public static class CompanyTypeExtensions
    {
        public static string CompanyAcronym(this CompanyType companyType)
        {
            switch (companyType)
            {
                case CompanyType.SquareRail:
                    return "SR";
                case CompanyType.CircleLine:
                    return "CL";
                case CompanyType.PentagonExpress:
                    return "PE";
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}
