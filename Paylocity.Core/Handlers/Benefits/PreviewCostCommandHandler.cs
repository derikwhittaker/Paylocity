using MediatR;
using Paylocity.Core.Calculators;
using Paylocity.Core.Models.Benefits;
using Paylocity.Core.Services;

namespace Paylocity.Core.Handlers.Benefits
{
    public class PreviewCostCommandHandler : IRequestHandler<PreviewCostCommand, PreviewCostCommandResponse>
    {
        private readonly IDiscountService _discountService;
        private readonly IBenefitCalculator _benefitCalculator;

        public PreviewCostCommandHandler(IDiscountService discountService, IBenefitCalculator benefitCalculator)
        {
            _discountService = discountService;
            _benefitCalculator = benefitCalculator;
        }

        public PreviewCostCommandResponse Handle(PreviewCostCommand message)
        {
            var member = message.Member;
            var discounts = _discountService.Determine(member);
            var costs = _benefitCalculator.Calculate(member, discounts);
            
            return new PreviewCostCommandResponse(member, costs);
        }
    }

    public class CalculateCostCommandHandler : IRequestHandler<CalculateCostCommand, CalculateCostCommandResponse>
    {
        private readonly IDiscountService _discountService;
        private readonly IBenefitCalculator _benefitCalculator;

        public CalculateCostCommandHandler(IDiscountService discountService, IBenefitCalculator benefitCalculator)
        {
            _discountService = discountService;
            _benefitCalculator = benefitCalculator;
        }

        public CalculateCostCommandResponse Handle(CalculateCostCommand message)
        {
            var employee = message.Employee;
            
            var employeeDiscounts = _discountService.Determine(employee.Member);
            var employeeCosts = _benefitCalculator.Calculate(employee.Member, employeeDiscounts);
            var runningAnnualCost = employeeCosts.AnnualCost;
            var runningDiscountAmount = employeeCosts.DiscountAmount;

            foreach (var dependant in message.Employee.Dependants)
            {
                var dependantDiscounts = _discountService.Determine(dependant);
                var dependantCosts = _benefitCalculator.Calculate(dependant, dependantDiscounts);

                runningAnnualCost += dependantCosts.AnnualCost;
                runningDiscountAmount += dependantCosts.DiscountAmount;
            }

            var calculatedBenefitCost = new BenefitCost(runningAnnualCost, runningDiscountAmount, 26);

            return new CalculateCostCommandResponse(message.Employee, calculatedBenefitCost);
        }
    }
}