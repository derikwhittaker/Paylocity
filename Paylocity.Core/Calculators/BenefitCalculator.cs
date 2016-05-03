using System.Collections.Generic;
using Paylocity.Core.Models;
using Paylocity.Core.Models.Benefits;
using Paylocity.Core.Services;

namespace Paylocity.Core.Calculators
{
    public interface IBenefitCalculator
    {
        BenefitCost Calculate(Member member, List<Discount> discounts);
    }

    public class BenefitCalculator : IBenefitCalculator
    {

        // clearly hard coding this would not work.  
        // IRL this would likely be a db lookup of some sort or have to assume the cost
        //  would be based off of the designaged plan which gets super hair for a coding challenge
        private const double EmployeeAnnualCost = 1000;
        private const double DependentAnnualCost = 500;
        private const int PayCycles = 26;

        private readonly ISalaryService _salaryService;

        public BenefitCalculator(ISalaryService salaryService)
        {
            _salaryService = salaryService;
        }

        public BenefitCost Calculate(Member member, List<Discount> discounts)
        {
            var runningCost = member.IsEmployee ? EmployeeAnnualCost : DependentAnnualCost;
            var orginalCost = runningCost;
           
            foreach (var discount in discounts)
            {
                runningCost = (1 - discount.DiscountPercent) * runningCost;
            }

            var discountAmount = orginalCost - runningCost;

            return new BenefitCost(runningCost, discountAmount, PayCycles);
        }
    }
}