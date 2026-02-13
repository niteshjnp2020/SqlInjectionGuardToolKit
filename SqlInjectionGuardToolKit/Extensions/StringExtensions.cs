using SqlInjectionGuardToolKit.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlInjectionGuardToolKit.Extensions
{
    public static class StringExtensions
    {
        public static string VerifySQlString(this string? value)
        {
            return new SafeString(value);
        }
    }
}
