using System.Collections.Generic;
using Newtonsoft.Json;

namespace Paylocity.Api.Models.Benefits
{
    public class Member
    {
        public string Name { get; set; }
        public bool IsEmployee { get; set; }
    }

    public class Employee
    {
        public Member Member { get; set; }

        public List<Member> Dependants { get; set; } = new List<Member>();

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }

    public class BenefitCost
    {
        public double AnnualCost { get; set; }
        public double MonthlyCost { get; set; }
        public double CycleCost { get; set; }
        public double DiscountAmount { get; set; }
        public double PayCycles { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }

}