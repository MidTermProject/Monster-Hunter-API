# Monster App 
-----
**Authors**: Ariel R. Pedraza, Luay Younus, Dustin Mundy<br />
**Version**: 1.0.0

## Overview
An API created from scratch used to request and modify a database of blademaster weapons for the game Monster Hunter Generations with CRUD routes.

## Getting Started
The following are required to run the program locally.
- [Visual Studio 2017 Community with .NET Core 2.0 SDK](https://www.microsoft.com/net/core#windowscmd)
- [GitBash / Terminal](https://git-scm.com/downloads) or [GitHub Extension for Visual Studio](https://visualstudio.github.com)

1. Clone the repository to your local machine.
2. Cd into the application directory where the `MonsterHunterAPI.sln` exist.
3. Open the application using `Open/Start MonsterHunterAPI.sln`.
4) Once the App is opened, Right click on the application name from the `Solution Explorer Window` and select `Add` -> `New Item` -> find `ASP.NET Configuration File` and open add it to the project.
- Inside this file, change the following Connection String to the database
```css
"ConnectionStrings": {
    "DefaultConnection": "Server=(localdb)\\MSSQLLocalDB;Database=TaskDB;Trusted_Connection=True;MultipleActiveResultSets=true"
}
```

5) Click `Tools` -> `NuGet Package Manager` -> `Package Manager Console` then run the following commands in the console.
```css
Install-Package Microsoft.EntityFrameworkCore.Tools
Add-Migration Initial
Update-Database
```
6. Once the database is updated, you can Run the application by clicking on the Play button <img src="https://github.com/luayyounus/Lab02-Unit-Testing/blob/Lab02-Luay/WarCardGame/play-button.jpg" width="16">.

## Database Diagram
![DatabaseSchema](https://raw.githubusercontent.com/MidTermProject/Monster-Hunter-API/master/Resources/MonsterHunterDBSchema.jpg?raw=true "MonsterHunter")

# API Endpoints

##### Link to deployment on Azure

[![APIEndPointBlade](https://raw.githubusercontent.com/MidTermProject/Monster-Hunter-API/master/Resources/azure-logo.png?raw=true) ](http://monsterhunterapi.azurewebsites.net/api/blade)

##### All End Points / Routes

![All End Points](https://raw.githubusercontent.com/MidTermProject/Monster-Hunter-API/master/Resources/API-Swagger.png?raw=true "API")


## Blades 

Getting all Blades from the Database

```yaml
GET: /api/blade/
```

Getting a single Blade by ID. This endpoint will return a list of materials in the returned Blade object

```yaml
GET: /api/blade/:bladeId
```

Filtering list of blades by Weapon Or/And Element Or/And Rarity

```yaml
GET: /api/blade/:weaponClass/:element/:rarity
```

Post/Create a new Weapon/Blade on the Database

```yaml
POST: api/blade
```

Update a blade/weapon

```yaml
PUT: api/blade/:id
```

Delete a blade from the database

```yaml
DELETE: api/blade/:id
```


#### Blade JSON Example
```json
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

## Materials

Getting all materials from Database

```yaml
GET: /api/material
```

Getting one material by ID

```yaml
GET: /api/material/:id
```

Posting a material with a list of locations

```yaml
POST: /api/material
```


#### Material Json Example
```json
[
    {
        "id": 1,
        "name": "Iron Ore",
        "rarity": 4,
        "description": null,
        "quantity": 0,
    },
    {
        "id": 2,
        "name": "Earth Crystal",
        "rarity": 4,
        "description": null,
        "quantity": 0
    },
    {
        "id": 3,
        "name": "Disc Stone",
        "rarity": 4,
        "description": null,
        "quantity": 0
    },
    {
        "id": 4,
        "name": "Machalite Ore",
        "rarity": 4,
        "description": null,
        "quantity": 0
    }
]
```

## Locations

Getting All Locations from Database

```yaml
GET: /api/location
```

Getting one Location by ID

```yaml
GET: /api/:locationId
```

Creating a new Location

A location object requires properties of `Name` and `Area`


```yaml
POST: api/Location
```

Update an existing Location

```yaml
PUT: api/Location/:id
````

Delete a location

```yaml
DELETE: api/Location/:id
```

#### Locations JSON Example
```json
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

### Frameworks & Dependencies
- Entity Framework Core
- ASP.NET Core
- Swashbuckle
- Xunit

## Architecture
C# ASP.NET Core MVC Application
