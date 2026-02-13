using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlInjectionGuardToolKit.Engines.Detection.Interfaces
{
    internal interface IInjectionPatternProvider
    {
        IEnumerable<string> GetPatterns();
    }
}
