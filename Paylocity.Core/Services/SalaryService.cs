using Paylocity.Core.Models;
using Paylocity.Core.Models.Benefits;

namespace Paylocity.Core.Services
{
    public interface ISalaryService
    {
        Salary Employee(Member member);
    }

    public class SalaryService : ISalaryService
    {
        public Salary Employee(Member member)
        {
            // every memeber has the same salary for this example
            return new Salary(52000, 26);
        }
    }
}