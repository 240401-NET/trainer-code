# Java to .NET


## Java to .NET in a nutshell
From the standard Java to standard .NET curriculum perspective

| Technology         | Java             | .NET                     |
| ------------------ | ---------------- | ------------------------ |
| Language           | Java             | C#                       |
| Dependency Manager | Maven/Gradle     | Nuget                    |
| Testing            | junit            | xunit                    |
| SQL Vendor         | MySQL/PostgreSQL | SQL Server               |
| DB access<br>      | jdbc             | ADO.NET                  |
| ORM                | Hibernate        | Entity Framework Core    |
| Web Framework      | javalin          | ASP.NET Core minimal API |
|                    | Spring           | ASP.NET Core             |


## Tech-by-tech Differences
### .NET
- .NET Platform provides comprehensive tooling/environment to develop different types of applications
	- This means we don't have to go look for our own package manager, etc. It comes all bundled in the SDK
- .NET releases yearly, with even numbers being LTS.
	- .NET 8 is the latest release
- The MSDoc is actually really good! (Although it can be hard to find actual doc vs their tutorial)
#### .NET Naming Issues
- .NET Framework is the first, windows-only implementation of .NET that is now super duper legacy
- .NET Core is their new cross platform implementation, starting with .NET Core 1
- Moving forward, they dropped the word "Core" and skipped number 4, and now all new releases of .NET is simply .NET (.NET Core 1 -> ... -> .NET Core 3.1 -> .NET 5 -> .NET 6, etc.)
- EXCEPT for frameworks.
	- Frameworks that exist both in .NET Framework and .NET (such as ASP.NET or Entity Framework) is differentiated by the word Core
		- ASP.NET is web framework for .NET framework. ASP.NET Core is web framework for .NET. 
		- EF is ORM for .NET framework, EF Core is ORM for .NET
#### Dependency Management
- Nuget is dependency manager for .NET. It comes preinstalled with all .NET SDK and by default looks for packages [here](https://www.nuget.org/)
- `dotnet add package <package-name>`: adds package dependency to your .csproj file.
	- *Common Error: All `dotnet add` commands have to be executed inside the project you're looking to add dependencies to. This is also common with people doing `dotnet run` outside the project*
#### .NET SDK commands cheat-sheet
- `dotnet --info`: information on .NET SDK
- `dotnet new ...`: scaffold a new project
	- `dotnet new console -n HelloWorld`: scaffold a new console app with the project name HelloWorld
	- `dotnet new gitignore`: create new .NET specific gitignore file
	- `dotnet new list`: List all templates available in dotnet new command
- `dotnet run`: clean, restore, build, run the project
	- `dotnet clean`: clean the build output
	- `dotnet restore`: make sure all dependencies are there and correctly configured
	- `dotet build`: compiles the code to DLL
	- `dotnet run`: do above 3 and run the DLL. 
	- Just tell associates `dotnet run`, others are more for debugging when stuff doesn't go right.
### C# 
- Language of choice for .NET
- Latest is C# 12 (with .NET 8)
- Strongly typed, mostly OO, some functional capabilities
- LINQ is amazing
- Has been making a lot of changes to look more like a scripting language, and increase its appeal to beginners.
#### Project
- In .NET, Projects are not your coding project. It is a unit containing source file + .csproj that compiles to .dll or .exe file. (also called assembly)
- .csproj file is your maven pom.xml, this is where all the project configuration + dependency management lives
- You can have multiple project working together. For easy management, you wrap that in to a solution, defined by .sln file. 
- It's common for .NET application to build multi-project coding projects.  
	- One project for models, one for data access, one for services, one for interface(console ui, api, etc)
	- You link these together with project references
	- `dotnet add reference <path-to-project-csproj-file>`
	- *Common Error: Order in which you reference these projects matters. If project A depends on project B to work, you add project B to project A as dependency. It does not do circular dependency.* 
	- There are different types of projects. `classlib` is a type that generates .dll file that are meant to be used by other projects that generate .exe file. (ie `console`)
#### Namespaces
- Packages in Java are Assemblies and Namespaces in C#. They are 2 different things. 
	- assembly is physical unit of deployment ie dll, exe etc., namespace is logical organization of types for encapsulation that can span multiple projects
		- In practice though, usually 1+ namespaces live in one project. Namespaces rarely span multiple projects.
	- There is no specific naming convention unlike Java (no com.revature.whatever)
- you declare namespace with the keyword `namespace`
- you import with the keyword `using`
- We don't import a specific type. We import the whole namespace.
- Namespaces can be file scoped since .NET 6 (you don't need curly braces afterwards)
#### Naming Convention
- PascalCase for TypeNames and MethodNames
- camelCase for variableNames
- We like our curly braces on new line
- interfaces start with the letter "I". IEnumerable, IQueryable, IList, etc.
- private field names start with underscore. ex: `private readonly ILogger _logger` 
- we name our data access classes "repository" instead of "dao"
	- i.e.: `public class TicketRepository : IRepository {}`
#### Types
- Most Java's primitives are in fact Structs in C#.
- We call them value-types and reference-types to indicate where in memory they live (stack vs managed heap)
- This means NO boxing of primitives is needed
	- `List<int> intList = new();` is valid code 
- Properties are fields with getters and setters. They are pretty cool and we tend to not declare separate fields unless we need some complicated behavior for getter/setter.
- There are a lot of short hands in C#. One of my favorite is object initializers that reduces the need of a ton of different constructors
- Iterable is IEnumerable in C#. Anything that implements IEnumerable can be iterated in foreach loop 
#### Collection names
- `List <T>` is Java's `ArrayList<T>`
- `Dictionary<TK, TV>` is Java's Hashmap
- `ArrayList` is non-generic List in C#! (don't use)
- In general, always opt for Generic versions of collections over non-generic. They also live in different namespaces. 
#### Unmanaged Resource
- Technically, unmanaged resources implement IDisposable, and can be disposed by calling the `dispose` method
- More common, though, is to use the `using` statement with the unmanaged resource and have them be disposed automatically once it's out of scope.

#### [LINQ](https://learn.microsoft.com/en-us/dotnet/csharp/linq/)
is amazing.
- Selling Point: "Uniform data manipulation interface for various collections in SQL-like syntax"
- As long as the collection/data structure implements IEnumerable or IQueryable, you can use LINQ
- Technically there are 2 types of syntax, method syntax and query syntax, but most people use the method syntax. Method syntax also makes it look very functional.
- Used extensively with EF Core(ORM)
- 1-line all your coding challenges with this!

#### Changes since C# 10 (That I think are fun/relevant)
- C# Console project no longer scaffolds with main method. It's still there under the hood but now we instead have top level statements that writes very much like a scripting language
	- As the name suggests, these TLS's have to come before any type declaration
- Reducing Vertical Clutter: Global Usings
	- use `global` keyword in front of `using` when importing namespaces and it will be available for the whole project instead of just the file.
	- convention is to have `global.cs` file for all these
- Reducing Horizontal Clutter: File-scoped namespaces, scope-scoped(?) using statements (using statements without curly braces) 
- Nullable for value-type is now enabled by default.
- [Pattern matching](https://learn.microsoft.com/en-us/dotnet/csharp/fundamentals/functional/pattern-matching) (is, switch, etc) is more widely supported 
- [Collection Expression](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/operators/collection-expressions): New feature of C#12! Terse way of declaring some collections such as Array and List. This allows us to do things like `List<int> intList = [1, 2, 3];` like how you'd do things in Python or JavaScript
- [Default value for lambda expressions](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/operators/lambda-expressions#input-parameters-of-a-lambda-expression): Default value was already supported for named methods, but now it's also supported for lambda's as well
- [`required` modifier](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/required) : To use with Object Initializers

### Entity Framework Core
- ORM for .NET
- EFCore + LINQ is like Spring Data
- 2 ways to sync code and db. Migrations (from code to db) or "code-first", and reverse scaffolding (from db to code) or "db-first". 
###  ASP.NET Core
- Web Framework for .NET
- Can be configured to serve different purposes
	- ASP.NET Core Minimal API (aka javalin)
	- ASP.NET Core WebAPI (fully fledged, API only)
	- ASP.NET Core MVC (API + server side rendering)
- Minimal API is a new addition since .NET 6 and it's really nice way to write lightweight API's
- A lot of conventions in place.
	- Especially the way you structure your endpoints, you can get away without specifying where to look for certain data in the endpoint
		- Route param: define in route defn and use the same name in method param
		- Query param: simple type method params (string, int, etc) that are not specified in the route
		- Body: if POST or PUT and complexly shaped (i.e class)
	- But you can also specify them for more clarity
- Model Binding is quite nice
	- Automatically deserialize your json to the type you specify and will respond with 4xx when things don't look right
- Framework configuration is done in program.cs file
- OpenAPI/Swagger comes preconfigured in WebAPI projects
	- You can also add that to minimal api with 4 lines of code
- appsettings.\*.json is configuration file for ASP.NET Core and where we store our DB connection string. These should be gitignored.
#### Dependency Injection
Dependency injection in ASP.NET Core is done through Services container
- Configured in Program.cs
- Lifetime of dependencies
	- Singleton (same one for the entire application lifecycle)
	- Scoped (one for the lifetime of the req/res cycle)
	- Transient (a new one created every single time)
	- Most dependencies should be Scoped

For full WebAPI projects, dependencies are constructor injected
```C#
private readonly ILogger<WorkoutController> _logger;
private readonly WorkoutService _service;

public WorkoutController(ILogger<WorkoutController> logger, WorkoutService service)
{
	_logger = logger;
	_service = service;
}
```

For minimal API projects, dependencies are brought in via as method parameter
```C# 
//Both are valid ways to inject WorkoutService as the dependency
app.MapGet("/workouts", ([FromQuery] string? search, [FromServices] WorkoutService service) => {
});
app.MapPost("/workouts", ([FromBody] WorkoutSession session, WorkoutService service) => {
});
```


### Azure
- Azure integrates really, really well with .NET applications
- App Services for deploying API's
	- provides you a way to inject project configuration per instance in the azure portal (things like connection string, etc)
	- You can also set up CORS policy in Azure app services resource portal (this is the easiest way to set up CORS policy, although doing it in the source code isn't too hard either)
- Static Web App for SPA's


For questions, comments, suggestions, please contact minseon.song@revature.com