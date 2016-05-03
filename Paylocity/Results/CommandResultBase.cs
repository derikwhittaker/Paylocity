using System.Collections.Generic;
using System.Linq;

namespace Paylocity.Core
{
    public class CommandResultBase
    {
        public List<ResultStatus> ResultErrors { get; set; } = new List<ResultStatus>();

        public bool HasErrors => ResultErrors.Any();
    }
}