using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlInjectionGuardToolKit.Models
{
    public class ValidatorOptions
    {
        public bool ReplaceUnsafeWithBlank { get; set; } = true;
        public List<string> CustomKeywords { get; set; } = new();
    }
}
