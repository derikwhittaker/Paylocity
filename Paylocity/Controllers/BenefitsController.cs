using System.Web.Http;
using AutoMapper;
using MediatR;
using Paylocity.Api.Models.Benefits;
using Paylocity.Core.Handlers.Benefits;

namespace Paylocity.Api.Controllers
{
    public class BenefitsController : BaseApiController
    {
        public IMapper Mapper { get; set; }

        public BenefitsController(IMediator mediator,  IMapper mapper) : base(mediator)
        {
            Mapper = mapper;
        }

        [Route("api/Benefits/PreviewCosts")]
        [HttpPost]
        public PreviewBenefitsCostResponse PreviewCosts(PreviewBenefitsCostRequest request)
        {
            
            var costCommand = Mapper.Map<PreviewCostCommand>(request);
            var costCommandResponse = Mediator.Send(costCommand);

            var costResponse = Mapper.Map<PreviewBenefitsCostResponse>(costCommandResponse);
            return costResponse;
        }

        [Route("api/Benefits/Costs")]
        [HttpPost]
        public BenefitsCostResponse Costs(BenefitsCostRequest request)
        {

            var costCommand = Mapper.Map<CalculateCostCommand>(request);
            var costCommandResponse = Mediator.Send(costCommand);
            
            var costResponse = Mapper.Map<BenefitsCostResponse>(costCommandResponse);
            return costResponse;
        }

    }
}
