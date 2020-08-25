using System;
using System.Collections.Generic;
using System.Linq;

namespace RollwayStation.Models
{
    public class Share
    {
        public Share(Die dieOne, Die dieTwo, CompanyType companyType)
        {
            if(dieOne == null || dieTwo == null)
            {
                throw new NullReferenceException();
            }

            var diceOrderedByValue = new List<Die> { dieOne, dieTwo }.OrderByDescending(x => x.Face).ToList();
            DieOne = diceOrderedByValue[0];
            DieTwo = diceOrderedByValue[1];
            CompanyType = companyType;
        }

        public Share(CompanyType companyType)
        {
            CompanyType = companyType;
            Burned = true;
        }

        public Die DieOne { get; }
        public Die DieTwo { get; }
        public CompanyType CompanyType { get; }
        public bool Burned { get; }

        public int DiceTotal => DieOne.Face + DieTwo.Face;
        public int DiceDifferential => DieOne.Face - DieTwo.Face;
    }
}
