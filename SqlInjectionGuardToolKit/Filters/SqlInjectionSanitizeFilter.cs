using Microsoft.AspNetCore.Mvc.Filters;
using SqlInjectionGuardToolKit.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlInjectionGuardToolKit.Filters
{
    public class SqlInjectionSanitizeFilter : IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            foreach (var arg in context.ActionArguments.Values)
            {
                if (arg == null)
                    continue;

                SqlInjectionValidator.SanitizeSafeClassStrings(arg);
            }
        }
        public void OnActionExecuted(ActionExecutedContext context)
        {
        }
    }
}
