using SqlInjectionGuardToolKit.Engines.Detection.Interfaces;
using SqlInjectionGuardToolKit.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlInjectionGuardToolKit.Engines.Detection
{
    internal class SqlKeywordDetector : IInjectionDetector
    {
        private readonly IInjectionPatternProvider _injectionPatternProvider;

        public SqlKeywordDetector(IInjectionPatternProvider injectionPatternProvider)
        {
            _injectionPatternProvider = injectionPatternProvider;
        }

        public ValidationResult Detect(string? input, string? location=null, ValidatorOptions? options = null)
        {
            options ??= new ValidatorOptions();
            if (string.IsNullOrWhiteSpace(input))
                return Safe(input, location);

            var patterns = (_injectionPatternProvider?.GetPatterns()?? Enumerable.Empty<string>())
                    .Concat(options.CustomKeywords ?? Enumerable.Empty<string>()).Distinct().ToList();
            var upperInput = input.ToUpperInvariant();

            var detected = patterns.FirstOrDefault(p => upperInput.Contains(p.ToUpperInvariant()));

            if (detected != null)
            {
                return new ValidationResult
                {
                    IsSafe = false,
                    OriginalValue = input,
                    SanitizedValue = options.ReplaceUnsafeWithBlank ? "" : input,
                    DetectedPattern = detected,
                    Location = location ?? ""
                };
            }

            return Safe(input, location);
        }

        private ValidationResult Safe(string? input, string? location)
        {
            return new ValidationResult
            {
                IsSafe = true,
                OriginalValue = input ?? "",
                SanitizedValue = input ?? "",
                DetectedPattern = "",
                Location = location ?? ""
            };
        }
    }

}
