using MediatR;
using Paylocity.Core.Models.Benefits;

namespace Paylocity.Core.Handlers.Benefits
{
    public class PreviewCostCommand : CommandRequestBase, IRequest<PreviewCostCommandResponse>
    {
        public Member Member { get; }

        public PreviewCostCommand( Member member)
        {
            Member = member;
        }
    }

    public class PreviewCostCommandResponse : CommandResultBase
    {
        public BenefitCost BenefitCost { get; }

        public Member Member { get; }

        public PreviewCostCommandResponse(Member member, BenefitCost benefitCost)
        {
            BenefitCost = benefitCost;
            Member = member;
        }
    }

}
