using SqlInjectionGuardToolKit.Core;
using SqlInjectionGuardToolKit.Engines.Detection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlInjectionGuardToolKit.Types
{
    public class SafeSqlProps
    {
        private readonly string? _value;
        private readonly bool _isSafe;
        private readonly string? _originalValue;

        public SafeSqlProps(string? value)
        {
            _originalValue = value;

            //var result = SqlInjectionValidator.SanitizeSafeClassStrings(value, "SafeSqlString");
            var detector = new SqlKeywordDetector(new SqlKeywordPatternProvider());
            var result = detector.Detect(value,nameof(value));
            _isSafe = result.IsSafe;
            _value = result.IsSafe ? value : result.SanitizedValue;
        }

        /// ✅ Expose Safety Status
        public bool IsSafe => _isSafe;

        /// ✅ Safe Value
        public string Value => _value ?? string.Empty;

        /// ✅ Original Value (Optional Debug)
        public string OriginalValue => _originalValue ?? string.Empty;

        /// ✅ Implicit FROM string → SafeSqlString
        public static implicit operator SafeSqlProps(string? value)
        {
            return new SafeSqlProps(value);
        }

        /// ✅ Implicit FROM SafeSqlString → string
        public static implicit operator string(SafeSqlProps safe)
        {
            return safe.Value;
        }

        ///Nice Debugging Experience
        public override string ToString()
        {
            return Value;
        }
    }
}
