# 🚀 SqlInjectionGuardToolKit

**SqlInjectionGuardToolKit** is a lightweight, enterprise-grade SQL Injection detection and sanitization library for .NET.

It helps developers automatically validate and sanitize potentially dangerous SQL patterns in user input with minimal configuration.

---

# 🎯 Why This Library Matters ⭐⭐⭐⭐⭐

SQL Injection is one of the most critical security vulnerabilities.

Without protection:

❌ Database compromise  
❌ Data leakage  
❌ Unauthorized data manipulation  
❌ Full system takeover  

This toolkit provides:

✅ Automatic validation  
✅ Safe input handling  
✅ Attribute-driven protection  
✅ Type-safe string design  
✅ DTO sanitization  
✅ MVC Filter / Middleware integration  

---

# ✅ Key Features ⭐⭐⭐⭐⭐🔥

✔ SQL Injection Pattern Detection  
✔ Automatic Sanitization  
✔ Attribute-Based Validation  
✔ SafeSqlString Type  
✔ MVC Filter Integration  
✔ Middleware Support  
✔ Console Validation Support  
✔ CLI Tool Support  
✔ Minimal Performance Overhead  

---



# 📦 Installation

---

## ✅ NuGet Package Manager

# ✅ 1️⃣ Enable SQL Injection Guard (Web API)

Register services:

```csharp
builder.Services.AddControllers();
builder.Services.AddSqlInjectionGuard();

```
or
```csharp
app.UseSqlInjectionGuard();
```
#✅ 2️⃣ DTO Validation (Attribute Mode)

Global Validation (Validate ALL string properties)
```csharp
[SafeClassString]
public class CreateUserRequest
{
    public string Name { get; set; }
    public string Email { get; set; }
}

```
Selective Validation (Validate specific properties)

```csharp
public class SearchRequest
{
    [SafeString]
    public string Keyword { get; set; }

    public string SortOrder { get; set; }
}

```
✅ 3️⃣ Type-Safe Protection (Recommended ⭐⭐⭐⭐⭐🔥)
```csharp
public class TestModel
{
    
    public SafeSqlProps Name { get; set; }
    public string? Username { get; set; }
}

```

✅ 3️⃣ Type-Safe Protection Individual String Check (Recommended ⭐⭐⭐⭐⭐🔥)
```csharp
public class TestModel
{
    
    public SafeSqlProps Name { get; set; }
    public string? Username { get; set; }
}

model.Username.VerifySQlString();
```
#🧠 How It Works

✅ Validation Flow
```csharp
User Input
    ↓
SqlInjectionValidator
    ↓
Pattern Detection Engine
    ↓
Sanitization Logic
    ↓
Safe Output

```

✅ Web API Protection Flow
```csharp
HTTP Request
    ↓
Middleware (Optional)
    ↓
MVC Filter
    ↓
DTO Validation

```
📜 License

MIT License


⭐ Final Thought ⭐⭐⭐⭐⭐🔥

Security should be:

✔ Automatic
✔ Predictable
✔ Hard to misuse
