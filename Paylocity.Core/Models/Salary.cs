namespace Paylocity.Core.Models
{
    public class Salary
    {
        public Salary(double annualRate, int cycles)
        {
            AnnualRate = annualRate;
            Cycles = cycles;
        }

        public double AnnualRate { get; }
        public double PerCheckRate => AnnualRate/Cycles;

        public int Cycles { get; }
   }
}