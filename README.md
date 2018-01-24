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

## Default Connection String to Database if used Locally
```
"ConnectionStrings": {

    "DefaultConnection": "Server=(localdb)\\MSSQLLocalDB;Database=TaskDB;Trusted_Connection=True;MultipleActiveResultSets=true"
```

4. Install Entity Framework, and build database with the following commands in the Package Manager Console:

### The main models/databases are:-
- Blade
- BladeMaterial (Intermediary DBSet)
- Material
- MaterialLocation (Intermediary DBSet)
- Location

### The main controllers are:-
- Blade Controller
- Material Controller
- Location Controller

## Database Diagram
![DatabaseSchema](https://raw.githubusercontent.com/MidTermProject/Monster-Hunter-API/master/Resources/MonsterHunterDBSchema.jpg?raw=true "MonsterHunter")

# API Endpoints

### Blades

Getting all Blades from the Database

`/api/blade/`

Getting a single Blade by ID. This endpoint will return a list of materials in the returned Blade object

`/api/blade/:bladeId`

Filtering list of blades by Weapon Or/And Element Or/And Rarity

`/api/blade/:weaponClass/:element/:rarity`

#### Example
```
[
    {
        "id": 1,
        "parent": null,
        "hasChild": true,
        "weaponClass": "Long Sword",
        "name": "Iron Katana 1",
        "description": "A Long Sword forged with Eastern methods. Durable and resilient, but requires regular upkeep.",
        "rawDamage": 70,
        "elementType": null,
        "elementDamage": 0,
        "sharpness": "Yellow",
        "rarity": 1,
        "affinity": 0,
        "slots": 0,
        "defense": 0,
        "imgUrl": null,
        "materials": null
    },
    {
        "id": 2,
        "parent": {
            "id": 1,
            "parent": null,
            "hasChild": true,
            "weaponClass": "Long Sword",
            "name": "Iron Katana 1",
            "description": "A Long Sword forged with Eastern methods. Durable and resilient, but requires regular upkeep.",
            "rawDamage": 70,
            "elementType": null,
            "elementDamage": 0,
            "sharpness": "Yellow",
            "rarity": 1,
            "affinity": 0,
            "slots": 0,
            "defense": 0,
            "imgUrl": null,
            "materials": null
        }
	}
]
```

### Locations

Getting All Locations from Database

`api/location`

Getting one Location by ID

`/api/:locationId`

#### Example
```
[
    {
        "id": 1,
        "name": "The Forrest",
        "area": 5,
        "dropRate": 13,
        "action": "mining"
    },
	{
        "id": 2,
        "name": "The Hill",
        "area": 12,
        "dropRate": 4,
        "action": "climbing"
    }
]
```

## Specs
- C# ASP.NET Core MVC Application
- Entity Framework 2.0
