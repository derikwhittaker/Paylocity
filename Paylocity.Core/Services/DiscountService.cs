using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Paylocity.Core.Models.Benefits;

namespace Paylocity.Core.Services
{
    public interface IDiscountService
    {
        List<Discount> Determine(Member member);
    }

    public class DiscountService : IDiscountService
    {
        private readonly List<IDiscountRule> _discountRules = new List<IDiscountRule>();

        // could wire up ioc to scan and find these but this is poc app
        public DiscountService()
        {
            _discountRules.Add(new FirstNameStartsWithADiscountRule());
        }

        public List<Discount> Determine(Member member)
        {
            var discounts = _discountRules.Select(r => r.Check(member)).ToList();

            return discounts.Where(x => x.DiscountPercent > 0).ToList();
        }
    }
}
