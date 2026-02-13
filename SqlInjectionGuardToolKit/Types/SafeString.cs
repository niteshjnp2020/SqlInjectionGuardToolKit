using SqlInjectionGuardToolKit.Core;
using SqlInjectionGuardToolKit.Engines.Detection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlInjectionGuardToolKit.Types
{
    public class SafeString
    {
        private readonly string? _value;
        private readonly string? _originalValue;
        private readonly bool _isSafe;

        public SafeString(string? value)
        {
            _originalValue = value;
            var detector = new SqlKeywordDetector(new SqlKeywordPatternProvider());
            var result = detector.Detect(value);

            //var result = SqlInjectionValidator.SanitizeString(value);

            _isSafe = result.IsSafe;
            _value = result.IsSafe ? value : string.Empty;
        }

        /// Clean Property Style
        public bool IsValid => _isSafe;

        /// Safe Value
        public string SafeValue() => _value ?? string.Empty;

        /// Original Value
        public string OriginalValue() => _originalValue ?? string.Empty;

        // Nullable-safe conversion
        public static implicit operator SafeString(string? value)
        {
            return new SafeString(value);
        }

        public static implicit operator string(SafeString safe)
        {
            return safe.SafeValue();
        }
    }
}
