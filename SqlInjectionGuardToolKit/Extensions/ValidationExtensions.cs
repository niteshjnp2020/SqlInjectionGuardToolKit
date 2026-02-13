using SqlInjectionGuardToolKit.Attributes;
using SqlInjectionGuardToolKit.Core;
using SqlInjectionGuardToolKit.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlInjectionGuardToolKit.Extensions
{
    public static class ValidationExtensions
    {
        public static List<ValidationResult> SanitizeSafeStrings(this object obj, ValidatorOptions? options = null)
        {           
            return SqlInjectionValidator.SanitizeSafeClassStrings(obj, options);
        }

    }
}
