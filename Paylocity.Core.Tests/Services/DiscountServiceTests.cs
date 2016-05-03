using FluentAssertions;
using Paylocity.Core.Models.Benefits;
using Paylocity.Core.Services;
using Xunit;

namespace Paylocity.Core.Tests.Services
{
    public class DiscountServiceTests
    {
        [Fact]
        public void Determine_WhenNameRuleIsFound_WillCheckAllRulesAndReturnOnlyDiscountsWithValues()
        {
            var service = new DiscountService();
            var member = new Member {Name = "Anthony Smith"};

            var discounts = service.Determine(member);

            discounts.Count.Should().Be(1);
        }


        [Fact]
        public void Determine_WhenNameRuleIsNotFound_WillCheckAllRulesAndReturnOnlyDiscountsWithValues()
        {
            var service = new DiscountService();
            var member = new Member { Name = "Tony Smith" };

            var discounts = service.Determine(member);

            discounts.Count.Should().Be(0);
        }


    }
}