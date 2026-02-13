using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SqlInjectionGuardToolKit.Engines.Scanning.Interfaces
{
    internal interface IModelScanner
    {
        IEnumerable<PropertyInfo> Scan(object modal);
    }
}
