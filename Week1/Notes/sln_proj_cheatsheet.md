# Cheatsheet: SLN files and managing multiple projects

## C# Projects

### Creating a project

To create a C# project, we use the ```dotnet new``` command.

The options we have used up to this point are ```dotnet new console``` for a C# console application, and ```dotnet new xunit``` for a new Xunit testing project. For the sake organization, it is best to give it an output directory.

For example the command:

```bash
dotnet new console -o DemoApplication
```

Creates a new C# console application inside of a new directory, DemoApplication. The same command structure will work for a unit test application. If we named out console app "DemoApplication", we would traditionally name our Xunit testing project something like "DemoApplication.Tests"

### Adding a Project Reference to a .csproj file

To be able to refer to code contained within the files of another project, we need to add a reference. For our demo, we added a reference inside of our Xunit testing project's .csproj file pointing to our console application's csproj file.

***It is best practice to avoid circular dependencies.*** If you find yourself having two projects that need to point at eachother, it is often the case that you need to go back to the drawing board and start seperating concerns a bit.

To add a reference we used the following command:

```bash
dotnet add ./dndRPGdemo/dndConsoleApp.Tests.csproj reference ./dndRPGdemo/dndConsoleApp.csproj
```

This command uses relative file paths (absolute file paths would also work) to add a project reference inside of our Xunit testing project pointing at the console application project. The reason we did this was so that we could use the Character class inside of the Xunit testing code. 

All that is left is to use a using statement to bring in the namespace the code we need resides in. In our case we used:

```csharp
using dndRPGdemo;
```

At the top of our file containing our tests. You could also throw it into a GlobalUsings.cs file, though this file is not strictly needed. If you feel the need to create a GlobalUsings.cs to store global using statements, go right ahead!

## SLN Files

### SLN File Creation

To create a new solution file in our current directory, we use the following command:

```bash
dotnet new sln
```

We would want this solution file to be at the same level as the directories for our project. For today's demo, we refactored our code to go from this original structure (before we wanted to leverage multiple projects):

|
|__dndRPGdemo directory
        |
        |__files for our console app

To this updated structure, with a .sln file.

|
|__dndRPGdemo directory
        |
        |__dndConsoleApp directory
        |       |
        |       |__files for our console app
        |
        |__dndConsoleApp.tests directory
        |       |
        |       |__files for our Xunit testing project
        |
        |__dbdRPGdemo.sln solution file

### Adding a project reference to a .sln file

To add a project reference to a .sln file, we use the following command:

```bash
dotnet sln -PATH-TO-.SLN-FILE- add -PATH-TO-OUR-.CSPROJ-FILE-
```

In our case, we ran this command twice to add our references for both our console application project and Xunit testing project.
