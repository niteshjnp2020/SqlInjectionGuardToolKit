using SqlInjectionGuardToolKit.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlInjectionGuardToolKit.Engines.Detection.Interfaces
{
    internal interface IInjectionDetector
    {
        ValidationResult Detect(string? input, string location, ValidatorOptions options);
    }
}
