using SqlInjectionGuardToolKit.Attributes;
using SqlInjectionGuardToolKit.Engines.Detection;
using SqlInjectionGuardToolKit.Engines.Scanning;
using SqlInjectionGuardToolKit.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SqlInjectionGuardToolKit.Core
{
    internal static class SqlInjectionValidator
    {
        public static List<ValidationResult> SanitizeSafeClassStrings(object model, ValidatorOptions? options = null)
        {
            options ??= new ValidatorOptions();

            var results = new List<ValidationResult>();

            var scanner = new ReflectionModelScanner();
            var detector = new SqlKeywordDetector(new SqlKeywordPatternProvider());

            var properties = scanner.Scan(model);

            foreach (var prop in properties)
            {
                var value = prop.GetValue(model) as string;

                var result = detector.Detect(value, prop.Name, options);

                if (!result.IsSafe && options.ReplaceUnsafeWithBlank)
                {
                    if (prop.CanWrite)
                        prop.SetValue(model, "");
                }

                results.Add(result);
            }

            return results;
        }

       
    }
}
