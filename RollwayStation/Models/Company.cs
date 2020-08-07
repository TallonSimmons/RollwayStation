using System;
using System.Collections.Generic;

namespace RollwayStation.Models
{
    public enum CompanyType { SquareRail, CircleLine, PentagonExpress }
    public class Company
    {
        private int shares;

        public Company(CompanyType companyType)
        {
            CompanyType = companyType;
        }

        public CompanyType CompanyType { get; }
        public List<Train> Trains { get; } = new List<Train>();
        public int Shares
        {
            get => shares;
            set => shares = value >= 0 && value <= 5 ? value : shares;
        }
        public bool SharesAvailable => Shares < 5;
        public string Name
        {
            get
            {
                switch (CompanyType)
                {
                    case CompanyType.SquareRail:
                        return "Square Rail";
                    case CompanyType.CircleLine:
                        return "Circle Line";
                    case CompanyType.PentagonExpress:
                        return "Pentagon Express";
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }
    }
}
