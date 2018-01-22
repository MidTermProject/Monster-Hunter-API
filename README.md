# Monster App 
-----
**Authors**: Ariel R. Pedraza, Luay Younus, Dustin Mundy<br />
**Version**: 1.0.0

## Overview
An API created from scratch used to request and modify a database of blademaster weapons for the game Monster Hunter Generations with CRUD routes.

## Getting Started
The following is required to run the program locally.
1. [Visual Studio 2017 Community with .NET Core 2.0 SDK](https://www.microsoft.com/net/core#windowscmd)
2. The .NET desktop development workload enabled
3. Ensure appsettings.json connection string is set to:
```
Install-Package Microsoft.EntityFrameworkCore.Tools
Add-Migration Initial
Update-Database
```

## Default Connection String to Database
```
"ConnectionStrings": {

    "DefaultConnection": "Server=(localdb)\\MSSQLLocalDB;Database=TaskDB;Trusted_Connection=True;MultipleActiveResultSets=true"
```

4. Install Entity Framework, and build database with the following commands in the Package Manager Console:

### The main models/databases are:-
- Blade Master Weapons
- Weapon Material Relation
- Crafting Material (representing materials of every weapon)
- WeaponMaterialRelation
- Locations

### The main two controllers are:-
- Weapon Controller
- Material Controller
- Location Controller

## Database Diagram
![DatabaseSchema](https://raw.githubusercontent.com/MidTermProject/Monster-Hunter-API/master/Resources/MonsterHunterDBSchema.jpg?raw=true "MonsterHunter")

### End Points
- TO BE IMPLEMENTED

## Specs
- C# ASP.NET Core MVC Application
- Entity Framework 2.0
