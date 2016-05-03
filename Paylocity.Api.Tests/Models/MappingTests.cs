using FluentAssertions;
using Xunit;

namespace Paylocity.Api.Tests.Models
{

    public class MappingTests
    {
        public MappingTests()
        {
            AutomapperConfig.Configure();
        }

        [Fact]
        public void Map_ApiMember_To_CoreMember()
        {
            var apiMember = new Api.Models.Benefits.Member
            {
                Name = "Bob",
                IsEmployee = true
            };

            var mappedMember = AutoMapper.Mapper.Instance.Map<Core.Models.Benefits.Member>(apiMember);

            mappedMember.Should().NotBeNull();
        }
    }
}
