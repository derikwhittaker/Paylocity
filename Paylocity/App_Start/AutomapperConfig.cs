using AutoMapper;
using Paylocity.Api.Models;

namespace Paylocity.Api
{
    public class AutomapperConfig
    {
        public static void Configure()
        {

            Mapper.Initialize(cfg =>
            {

                cfg.SourceMemberNamingConvention = new PascalCaseNamingConvention();
                cfg.DestinationMemberNamingConvention = new PascalCaseNamingConvention();

                cfg.AddProfile<ApiProfile>();
            });
            
        }
    }
}