using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlInjectionGuardToolKit.Models
{
    public class ValidationResult
    {
        public bool IsSafe { get; set; }
        public string OriginalValue { get; set; } = string.Empty;

        public string SanitizedValue { get; set; } = string.Empty;
        public string DetectedPattern { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;

    }
}
