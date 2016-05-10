using System.Collections.Generic;
using FluentAssertions;
using Paylocity.Core.Calculators;
using Paylocity.Core.Handlers.Benefits;
using Paylocity.Core.Models.Benefits;
using Paylocity.Core.Services;
using Xunit;

namespace Paylocity.Core.Tests.Handlers.Benefits
{
    public class CalculateCostCommandHandlerTests
    {


        [Fact]
        public void Handle_When2Dependants_NoDiscounts_WIllReturnCorrect()
        {
            var discountService = new DiscountService();
            var salaryService = new SalaryService();
            var benefitCalculator = new BenefitCalculator(salaryService);

            var handler = new CalculateCostCommandHandler(discountService, benefitCalculator);

            var employee = new Employee
            {
                Member = new Member { IsEmployee = true, Name = "Sam"},
                Dependants = new List<Member>
                {
                    new Member {Name = "Sally"},
                    new Member {Name = "Marry"},
                }
            };

            var calculateCostCommand = new CalculateCostCommand(employee);

            var response = handler.Handle(calculateCostCommand);
            response.BenefitCost.Should().NotBeNull();
            response.BenefitCost.AnnualCost.Should().Be(2000);
            response.BenefitCost.DiscountAmount.Should().Be(0);
            response.BenefitCost.CycleCost.Should().Be(76.92);
        }

        [Fact]
        public void Handle_When2Dependants_EmployeeHasDiscounts_WIllReturnCorrect()
        {
            var discountService = new DiscountService();
            var salaryService = new SalaryService();
            var benefitCalculator = new BenefitCalculator(salaryService);

            var handler = new CalculateCostCommandHandler(discountService, benefitCalculator);

            var employee = new Employee
            {
                Member = new Member { IsEmployee = true, Name = "Anthony" },
                Dependants = new List<Member>
                {
                    new Member {Name = "Sally"},
                    new Member {Name = "Marry"},
                }
            };

            var calculateCostCommand = new CalculateCostCommand(employee);

            var response = handler.Handle(calculateCostCommand);
            response.BenefitCost.Should().NotBeNull();
            response.BenefitCost.AnnualCost.Should().Be(1900);
            response.BenefitCost.DiscountAmount.Should().Be(100);
            response.BenefitCost.CycleCost.Should().Be(73.08);
        }

        [Fact]
        public void Handle_When2Dependants_DependantHasDiscounts_WIllReturnCorrect()
        {
            var discountService = new DiscountService();
            var salaryService = new SalaryService();
            var benefitCalculator = new BenefitCalculator(salaryService);

            var handler = new CalculateCostCommandHandler(discountService, benefitCalculator);

            var employee = new Employee
            {
                Member = new Member { IsEmployee = true, Name = "Tony" },
                Dependants = new List<Member>
                {
                    new Member {Name = "Abby"},
                    new Member {Name = "Marry"},
                }
            };

            var calculateCostCommand = new CalculateCostCommand(employee);

            var response = handler.Handle(calculateCostCommand);
            response.BenefitCost.Should().NotBeNull();
            response.BenefitCost.AnnualCost.Should().Be(1950);
            response.BenefitCost.DiscountAmount.Should().Be(50);
            response.BenefitCost.CycleCost.Should().Be(75.00);
        }
    }
}
