using SqlInjectionGuardToolKit.Engines.Detection.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlInjectionGuardToolKit.Engines.Detection
{
    internal class SqlKeywordPatternProvider : IInjectionPatternProvider
    {
        public IEnumerable<string> GetPatterns()
        {
            return new List<string>
            {
                
                 //SQL Commands
                 "SELECT", "INSERT", "UPDATE", "DELETE",
                 "DROP", "TRUNCATE", "ALTER", "EXEC",
                 "UNION", "MERGE", "CALL","Union","Union All",


                 //Logical Operators and Common Injection Patterns
                 " OR ", " AND ",
                 " < "," > ",
                 "= ", "!= ", "<> ",
                 "--", ";--", ";", "/*", "*/",
                 "1=1", "1 = 1",
                 "' OR '1'='1",
                 "\" OR \"1\"=\"1",


                 //System / Metadata Access
                 "INFORMATION_SCHEMA",
                 "SYSOBJECTS",
                 "SYSCOLUMNS",
                 "@@", "@@",

                 // Dangerous Stored Procedures
                 "XP_", "SP_",

                 // Time-Based Injection
                 "SLEEP(", "BENCHMARK(",
                 "WAITFOR", "DELAY",

                 // Encoding / Obfuscation Tricks
                 "CHAR(", "NCHAR(",
                 "VARCHAR(", "NVARCHAR(",

                 // Data Manipulation Tricks
                 "CAST(", "CONVERT(",

                 // Execution / Dynamic SQL
                 "DECLARE", "OPENROWSET",
                 "OPENDATASOURCE"
            };
        }
    }
}
