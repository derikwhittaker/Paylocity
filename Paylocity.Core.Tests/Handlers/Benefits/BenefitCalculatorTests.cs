using System.Collections.Generic;
using FluentAssertions;
using Paylocity.Core.Calculators;
using Paylocity.Core.Models.Benefits;
using Paylocity.Core.Services;
using Xunit;

namespace Paylocity.Core.Tests.Handlers.Benefits
{
    public class BenefitCalculatorTests
    {
        [Fact]
        public void Calculate_MemberIsEmployee_NoDiscounts_WillReturnCorrect()
        {
            var calculator = CreateCalculator();
            var member = new Member {IsEmployee = true};
            var discounts = new List<Discount>();

            var cost = calculator.Calculate(member, discounts);

            cost.AnnualCost.Should().Be(1000);
        }

        [Fact]
        public void Calculate_MemberIsEmployee_WithDiscounts_WillReturnCorrect()
        {
            var calculator = CreateCalculator();
            var member = new Member { IsEmployee = true };
            var discounts = new List<Discount> {new Discount(.10)};

            var cost = calculator.Calculate(member, discounts);

            cost.AnnualCost.Should().Be(900);
        }

        [Fact]
        public void Calculate_MemberIsNotEmployee_WithNoDiscounts_WillReturnCorrect()
        {
            var calculator = CreateCalculator();
            var member = new Member { IsEmployee = false };
            var discounts = new List<Discount> ();

            var cost = calculator.Calculate(member, discounts);

            cost.AnnualCost.Should().Be(500);
        }

        [Fact]
        public void Calculate_MemberIsNotEmployee_WithDiscounts_WillReturnCorrect()
        {
            var calculator = CreateCalculator();
            var member = new Member { IsEmployee = false };
            var discounts = new List<Discount> { new Discount(.10) };

            var cost = calculator.Calculate(member, discounts);

            cost.AnnualCost.Should().Be(450);
        }

        private IBenefitCalculator CreateCalculator()
        {
            // should use a mocking engine if scenerio gets harder
            return new BenefitCalculator(new SalaryService());
        }
    }
}
