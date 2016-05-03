using System.Globalization;
using Paylocity.Core.Models.Benefits;

namespace Paylocity.Core.Services
{
    public class FirstNameStartsWithADiscountRule : IDiscountRule
    {
        public Discount Check(Member member)
        {
            if( string.IsNullOrEmpty(member.Name)) { return new Discount();}

            if (member.Name.ToLower(CultureInfo.CurrentCulture).StartsWith("a"))
            {
                return new Discount(.10);
            }

            return new Discount();
        }
    }
}