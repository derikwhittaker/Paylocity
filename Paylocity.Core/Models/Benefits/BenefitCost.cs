

using System;

namespace Paylocity.Core.Models.Benefits
{
    public class BenefitCost
    {

        public BenefitCost(double annualCost, double discountAmount, int payCycles)
        {
            AnnualCost = annualCost;
            DiscountAmount = discountAmount;
            PayCycles = payCycles;
        }

        public double AnnualCost { get; }
        public double DiscountAmount { get; }

        public double MonthlyCost
        {
            get
            {
                if (PayCycles > 0)
                {
                    return Math.Round(AnnualCost / 12, 2);
                }

                return 0;
            }
        }

        public double CycleCost
        {
            get
            {
                if (PayCycles > 0)
                {
                    return Math.Round( AnnualCost / PayCycles, 2);
                }

                return 0;
            }
        }

        public int PayCycles { get; }

    }
}
