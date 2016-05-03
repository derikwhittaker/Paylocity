using Paylocity.Core.Models.Benefits;

namespace Paylocity.Core.Services
{
    public interface IDiscountRule
    {
        Discount Check(Member member);
    }
}