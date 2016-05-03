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
}