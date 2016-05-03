

namespace Paylocity.Core.Models.Benefits
{
    public class BenefitCost
    {
        public double AnnualCost { get; }

        public double MonthlyCost
        {
            get
            {
                if (PayCycles > 0)
                {
                    return AnnualCost/12;
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
                    return AnnualCost / PayCycles;
                }

                return 0;
            }
        }

        public int PayCycles { get; }

        public BenefitCost(double annualCost, int payCycles)
        {
            AnnualCost = annualCost;
            PayCycles = payCycles;
        }
    }
}
