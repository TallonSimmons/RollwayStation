using System;
using System.Collections.Generic;

namespace RollwayStation.Models
{
    public enum CompanyType { SquareRail, CircleLine, PentagonExpress }
    public class Company
    {
        public Company(CompanyType companyType)
        {
            CompanyType = companyType;
        }

        public CompanyType CompanyType { get; }
        public List<Train> Trains { get; } = new List<Train>();
        public List<Share> Shares { get; } = new List<Share>();
        public int NumberOfSharesOwned => Shares.Count;
        public bool SharesAvailable => NumberOfSharesOwned < 5;
        public string Name
        {
            get
            {
                return CompanyType switch
                {
                    CompanyType.SquareRail => "Square Rail",
                    CompanyType.CircleLine => "Circle Line",
                    CompanyType.PentagonExpress => "Pentagon Express",
                    _ => throw new ArgumentOutOfRangeException(),
                };
            }
        }
    }
}
