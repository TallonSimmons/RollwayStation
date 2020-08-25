using RollwayStation.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RollwayStation.Services
{
    public class SharesService
    {
        private readonly Store store;
        private Share lastAddedShare;

        public SharesService(Store store)
        {
            this.store = store;
        }

        public List<Share> GetShareOptions(Die dieOne, Die dieTwo)
        {
            if (dieOne == null || dieTwo == null)
            {
                throw new NullReferenceException();
            }

            var diceOrderedByFaceValue = new List<Die> { dieOne, dieTwo }.OrderByDescending(x => x.Face).ToList();
            dieOne = diceOrderedByFaceValue[0];
            dieTwo = diceOrderedByFaceValue[1];

            var availablePurchaseTypes = new List<Share>();
            var diceTotal = dieOne.Face + dieTwo.Face;
            var diceMatch = dieOne.Face == dieTwo.Face;
            var diceDifferential = dieOne.Face - dieTwo.Face;
            var diceEqualSeven = diceTotal == 7;

            if (diceMatch
                && !store.CircleLine.Shares.Any(x => diceTotal == x.DiceTotal)
                && store.CircleLine.SharesAvailable)
            {
                availablePurchaseTypes.Add(new Share(dieOne, dieTwo, CompanyType.CircleLine));
            }
            var lastSquareRailShare = store.SquareRail.Shares.LastOrDefault();
            if (diceDifferential > 0
                && (lastSquareRailShare?.DiceDifferential < diceDifferential || lastSquareRailShare == null)
                && store.SquareRail.SharesAvailable)
            {
                availablePurchaseTypes.Add(new Share(dieOne, dieTwo, CompanyType.SquareRail));
            }
            if (diceEqualSeven && store.PentagonExpress.SharesAvailable)
            {
                availablePurchaseTypes.Add(new Share(dieOne, dieTwo, CompanyType.PentagonExpress));
            }

            return availablePurchaseTypes;
        }

        public void BuyShare(Share share)
        {
            store.Companies
                .FirstOrDefault(x => x.CompanyType == share.CompanyType)
                .Shares
                .Add(share);
            store.CurrentRound.Share = share;
            lastAddedShare = share;
        }

        public void ReturnShare()
        {
            var targetCompany = store.Companies
                   .FirstOrDefault(x => x.CompanyType == lastAddedShare.CompanyType);

            targetCompany.Shares.Remove(targetCompany.Shares.LastOrDefault());

            store.CurrentRound.Share = null;
            lastAddedShare = null;
        }

        public void BurnShare(CompanyType companyType)
        {
            var targetCompany = store.Companies.FirstOrDefault(company => company.CompanyType == companyType);
            var burnedShare = new Share(companyType);
            targetCompany.Shares.Add(burnedShare);
            store.CurrentRound.Share = burnedShare;
            lastAddedShare = burnedShare;
        }
    }
}
