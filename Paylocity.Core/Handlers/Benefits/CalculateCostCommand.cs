using MediatR;
using Paylocity.Core.Models.Benefits;

namespace Paylocity.Core.Handlers.Benefits
{
    public class CalculateCostCommand : CommandRequestBase, IRequest<CalculateCostCommandResponse>
    {
        public Employee Employee { get; }

        public CalculateCostCommand(Employee employee)
        {
            Employee = employee;
        }
    }
    
    public class CalculateCostCommandResponse : CommandResultBase
    {
        public BenefitCost BenefitCost { get; }

        public Employee Employee { get; }

        public CalculateCostCommandResponse(Employee employee, BenefitCost benefitCost)
        {
            BenefitCost = benefitCost;
            Employee = employee;
        }
    }
}