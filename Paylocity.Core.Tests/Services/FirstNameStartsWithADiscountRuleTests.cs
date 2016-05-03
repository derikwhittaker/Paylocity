using System.Collections.Generic;
using FluentAssertions;
using Paylocity.Core.Models.Benefits;
using Paylocity.Core.Services;
using Xunit;

namespace Paylocity.Core.Tests.Services
{
    public class FirstNameStartsWithADiscountRuleTests
    {
        [Fact]
        public void Check_WhenMemberNameIsEmpty_ReturnNonDiscount()
        {
            var rule = new FirstNameStartsWithADiscountRule();
            var member = new Member {Name = string.Empty};

            var discount = rule.Check(member);

            discount.Should().NotBeNull();
            discount.DiscountPercent.Should().Be(0);
        }

        [Fact]
        public void Check_WhenMemberNameStartsWithA_ReturnDiscount()
        {
            var rule = new FirstNameStartsWithADiscountRule();
            var member = new Member { Name = "Anthony Smith" };

            var discount = rule.Check(member);

            discount.Should().NotBeNull();
            discount.DiscountPercent.Should().Be(0.10);
        }
        
        [Fact]
        public void Check_WhenMemberNameDoesNotStartsWithA_ReturnNonDiscount()
        {
            var rule = new FirstNameStartsWithADiscountRule();
            var member = new Member { Name = "Tony Smith" };

            var discount = rule.Check(member);

            discount.Should().NotBeNull();
            discount.DiscountPercent.Should().Be(0);
        }
    }
}