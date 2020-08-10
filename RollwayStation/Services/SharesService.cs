using RollwayStation.Components;
using RollwayStation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

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

            var diceOrderedByFaceValue = new List<Die> { dieOne, dieTwo }.OrderBy(x => x.Face).ToList();
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
            if (diceDifferential > 0
                && store.SquareRail.Shares?.LastOrDefault()?.DiceDifferential < diceDifferential
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
    }
}
