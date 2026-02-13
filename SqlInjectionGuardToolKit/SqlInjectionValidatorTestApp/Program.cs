using SqlInjectionGuardToolKit.Attributes;
using SqlInjectionGuardToolKit.Extensions;
using SqlInjectionGuardToolKit.Types;
using System.Reflection;


public class TestModel
{
    
    public SafeSqlProps Name { get; set; }
    public string? Username { get; set; }
}

class Program
{
    static void Main(string[] args)
    {
        var model = new TestModel
        {
            Name = "DROP TABLE Users",
            Username = "DROP TABLE Users"
        };
       
        var results = model.SanitizeSafeStrings();

        Console.WriteLine("---- VALIDATION RESULTS ----");

        foreach (var result in results)
        {
            Console.WriteLine($"Property: {result.Location}");
            Console.WriteLine($"Is Safe: {result.IsSafe}");
            Console.WriteLine($"Keyword: {result.DetectedPattern}");
            Console.WriteLine($"Original: {result.OriginalValue}");
            Console.WriteLine($"Sanitized: {result.SanitizedValue}");
            Console.WriteLine("--------------------------------");
        }

        Console.WriteLine("---- MODEL AFTER SANITIZE ----");
        Console.WriteLine($"Name: {model.Name}");
        Console.WriteLine($"Username: {model.Username}");
    }
}