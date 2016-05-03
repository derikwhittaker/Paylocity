using AutoMapper;
using Paylocity.Api.Models.Benefits;
using Paylocity.Core.Handlers.Benefits;
using ApiModels = Paylocity.Api.Models;
using CoreModels = Paylocity.Core.Models;

namespace Paylocity.Api.Models
{
    public class ApiProfile : Profile
    {
        protected override void Configure()
        {
            // Inbound
            CreateMap<Benefits.Member, CoreModels.Benefits.Member>();

            CreateMap<PreviewBenefitsCostRequest, PreviewCostCommand>()
                .ForMember(d => d.Member, x => x.MapFrom(s => s.Member));

            // Outbound
            CreateMap<CoreModels.Benefits.Member, Benefits.Member>();
            CreateMap<CoreModels.Benefits.BenefitCost, Benefits.BenefitCost>();

            CreateMap<PreviewCostCommandResponse, PreviewBenefitsCostResponse>()
                .ForMember(d => d.Member, x => x.MapFrom(s => s.Member))
                .ForMember(d => d.BenefitCost, x => x.MapFrom(s => s.BenefitCost))
                ;
        }
    }
}