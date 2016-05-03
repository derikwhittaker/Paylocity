using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
        public string Name { get; set; }

        public List<Dependant> Dependants { get; set; } = new List<Dependant>();

        public override string ToString()
        {
            return JsonConvert.SerializeObject(new {Name});
        }
    }

    public class BenefitCost
    {
        public double AnnualCost { get; set; }
        public double MonthlyCost { get; set; }
        public double CycleCost { get; set; }
        public double DiscountAmount { get; set; }
        public double PayCycles { get; set; }
    }

    public class Dependant
    {
        public string Name { get; set; }
        public bool IsSpouse { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }

}