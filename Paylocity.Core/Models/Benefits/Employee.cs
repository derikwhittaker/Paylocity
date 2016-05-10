using System.Collections.Generic;

namespace Paylocity.Core.Models.Benefits
{
    public class Employee
    {
        public Member Member { get; set; }

        public List<Member> Dependants { get; set; } = new List<Member>();
        
    }
}