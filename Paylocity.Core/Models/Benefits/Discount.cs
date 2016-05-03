namespace Paylocity.Core.Models.Benefits
{
    public class Discount
    {
        public double DiscountPercent { get; } = 0;

        public Discount()
        {
            
        }

        public Discount(double discountPercent)
        {
            DiscountPercent = discountPercent;
        }
    }
}