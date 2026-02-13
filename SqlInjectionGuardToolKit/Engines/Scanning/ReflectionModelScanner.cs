using SqlInjectionGuardToolKit.Attributes;
using SqlInjectionGuardToolKit.Engines.Scanning.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SqlInjectionGuardToolKit.Engines.Scanning
{
    internal class ReflectionModelScanner : IModelScanner
    {
        public IEnumerable<PropertyInfo> Scan(object model)
        {
            var type = model.GetType();

            bool validateAll =type.GetCustomAttribute<SafeClassStringAttribute>() != null;
            
            foreach (var prop in type.GetProperties())
            {
                if (prop.PropertyType != typeof(string))
                    continue;
                if (validateAll)
                {
                    yield return prop;
                    continue;
                }

                if (prop.GetCustomAttribute<SafeStringAttribute>() == null)
                    continue;

                yield return prop;
            }
        }
    }
}
