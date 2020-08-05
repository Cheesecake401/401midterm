# Crypts and Coders
API hosted at: *dummy.com*

## Vision
This app is designed to alleviate the burden of keeping track of DnD campaigns across an array of notebooks and scattered character sheets. Running a table top RPG can be very difficult work, and often requires a lot of note keeping to keep track of all the characters, enemies, locations, etc. This API brings that all to one place, where the Game Master can see and update any information in the game, and players can see and keep track of their own information. Finally, no more pain from forgotten character sheets and coffee-soiled notes, keep all the information needed in one easy and convenient API.

## Scope
### IN
- This API will allow a user to create and keep track of their information throughout a DnD campaign.
- The API will let Game Masters control everything in the database, adding and removing custom items to each table as needed. 
- The API will provide limited seeded data to start and then allow the Game Master user full control.
- The API will be configured to show all relevant information in a way that conforms to RESTful standards.

### OUT
- The API will not provide all of the classes, species, items, etc. available in DnD, nor all of their attributes.

### MVP
The MVP for this API is a simple set up using 6 tables to represent Characters, enemies, weapons, locations, items, and stats which will all be joined together and displayed following RESTful standards. It will also utilize basic authorization to allow players to only view their own character's informaiton but allow the GM full access to all routes.

### Stretch
- Event log table that will store events that are posted to the API with all relevant information.
- Sophisticated interactions to allow players to "Loot" slain enemies or "Trade" with other players.
- Pull in items, classes and other information from DnD API to have a more robust initial data seed.

## Functional Requirements
- A Game Master has full access to read, update, add and delete any and all objects in all tables.
- A Player can view all of their own information, including Weapon, Stats, Inventory and current locaiton, and can update some parts.
- An anonymous user can view assets not related to the ongoing game such as enemies but not their locations, items but not who has them, etc.

### Data Flow
A user will make any kind of request to the API, it will be processed if the information given is correct and they the user has appropriate authorization in the for of a JWT token, the data will be queried and either update or return the information supplied the user.
The various routes and their methods are listed below.

## Non-Functional Requirements 
- Security: Our app will utilize ASP.NET Identity framework in order to add a layer of both security and authorizaiton to the data. The information will be primarily overseen by one user, the Game Master, and they will be the only user with all authorization. Players will only be able to view their own information after entering in their username and passwords to receive authorization. All of the authorization is being handled via JWT tokens.
- Testability: All of the services on our app will have tests for every method to ensure that they can handle the data correctly. The services are used to handle what happens for each of the routes and the tests will ensure that any queries are being handled correctly as long as the inputs are correct. The testing is done using the XUnit testing framework.

## Planned Endpoints
### Characters
*/Characters*

**Authorization** - GM only

**Get** - All characters and their information (including Inventory, Stats and Weapon)

**Post** - Create new character by supplying: WeaponId, Current Location ID, Name, Species, and Class


*/Characters/{Name}* 

**Authorization** - GM can do anything, users can update and view their own character

**Get** - Character with the given name and their associated information.

**Put** - Update character info

**Samples**

*In:*
```
{
    "id": 1,
    "name": "Galdifor",
    "species": "Elf",
    "class": "Thief",
    "weaponId": 1,
    "locationId": 1
}
```
*Out:*
```
{
    "id": 1,
    "name": "Galdifor",
    "species": "Elf",
    "class": "Thief",
    "weaponId": 1,
    "weapon": {
        "id": 1,
        "name": "Put Weapon",
        "type": "Close Range",
        "baseDamage": 15
    },
    "locationId": 1,
    "currentLocation": {
        "id": 1,
        "name": "FaldorPUT",
        "description": "Occupied by the forces of evil, Faldor consists of open, hilly plains that separate it's eastern border with towering mountains.",
        "enemies": [
            {
                "id": 1,
                "abilities": "PUT",
                "type": "Warrior",
                "species": "Goblin"
            },
            {
                "id": 2,
                "abilities": "Smash",
                "type": "Beast",
                "species": "Troll"
            }
        ]
    },
    "inventory": [
        {
            "characterId": 1,
            "itemId": 1,
            "item": {
                "id": 1,
                "name": "Health Potion PUT",
                "value": 25
            }
        },
        {
            "characterId": 1,
            "itemId": 2,
            "item": {
                "id": 2,
                "name": "Cup",
                "value": 5
            }
        }
    ],
    "statSheet": [
        {
            "statId": 1,
            "characterId": 1,
            "level": 0,
            "stat": {
                "name": "Put Stat",
                "id": 1
            }
        },
        {
            "statId": 3,
            "characterId": 1,
            "level": 8,
            "stat": {
                "name": "Constitution",
                "id": 3
            }
        }
    ],
    "userName": "RedHawk"
}
```

### Character Stats
*Character/{{CharacterId}}/Stats* 

**Authorization** - Allow anonymous for all get, DM only for post

**Get** - All of a specific character's stats

**Post** - Create new character by supplying: Stat, Character, and Level

*Character/{{CharacterId}}/Stats/{{StatId}}* 

**Authorization** - Allow anonymous for all get specific Character Stats, DM only for put

**Get** - One of a specific character's stats

**Put** - Update CharacterStats info

**Samples**

*In:*
```
{
    "statId": 1,
    "characterId": 1,
    "level": 8,
}
```
*Out:*
```
{
    "statId": 1,
    "characterId": 1,
    "level": 8,
    "stat": {
        "name": "Stealth",
        "id": 1
    }
}
```

### Locations
*/Locations*

**Authorization** - GM only

**Get** - All Locations and their information (characters and enemies in location)

**Post** - Create new location by supplying: Name and Description


*/Locations/{{LocationId}}* 

**Authorization** - Users can get their current location, only GM for other operations

**Get** - Location with the given name and their associated information.

**Put** - Update location info

**Samples**

*In:*
```
{
    "id": 1,
    "name": "Falador",
    "description": "Occupied by the forces of evil, Falador consists of open, hilly plains that separate it's eastern border with towering mountains."
}
```
*Out:*
```
{
    "id": 1,
    "name": "FaldorPUT",
    "description": "Occupied by the forces of evil, Faldor consists of open, hilly plains that separate it's eastern border with towering mountains.",
    "enemies": [
        {
            "id": 1,
            "abilities": "PUT",
            "type": "Warrior",
            "species": "Goblin"
        },
        {
            "id": 2,
            "abilities": "Smash",
            "type": "Beast",
            "species": "Troll"
        }
    ]
}
```

### Enemies
*/Enemies*

**Authorization** - Get allows anonymous, Post is GM only

**Get** - All Enemies and their information

**Post** - Create new enemy by supplying: Name and Description


*/Enemies/{{Name}}* 

**Authorization** - Get allows anonymous, Put & Delete are GM only

**Get** - Enemy with the given name and their associated information.

**Put** - Update enemy info

**Delete** - Delete enemy from database


**Samples**

*In:*
```
{
    "id": 1,
    "abilities": "Smack",
    "type": "Warrior",
    "species": "Goblin"
}
```
*Out:*
```

```


### Items
*/Items*

**Authorization** - Allow anonymous for all gets, DM only for post

**Get** - All Items and their information

**Post** - Create new item by supplying: Name and Value


*/Items/{id}* 

**Authorization** - Allow anonymous for all gets, DM only for put

**Get** - Item with the given id and it's associated information.

**Put** - Update item info

**Samples**

*In/Out:*
```
{
    "id": 1,
    "name": "Health Potion",
    "value": 25
}
```


### Weapons
*/Weapons*

**Authorization** - Allow anonymous for all get, DM only for post

**Get** - All Weapon items and their information

**Post** - Create new weapon by supplying: Name and type

*/Weapons/{id}* 

**Authorization** - Allow anonymous for all gets, DM only for put

**Get** - Weapon with the given id and it's associated information.

**Put** - Update weapon info

**Samples**

*In/Out:*
```
{
    "id": 1,
    "name": "Put Weapon",
    "type": "Close Range",
    "baseDamage": 15
}
```


### Enemy Loot

*Enemies/{EnemyId}/ItemId/EnemyLoot*

**Authorization** - Allow anonymous for all get, DM only for post

**Get** - All Enemies and EnemyLoot 

**Post** - Create new Enemy Loot by supplying: Character and Item 

*Enemies/{CharacterId}/ItemId/EnemyLoot*

**Authorization** - Allow anonymous for all gets, DM only for put

**Get** - Item with the given id inside EnemyLoot

**Put** - Update item in Enemy Loot

**Samples**

*In:*
```

```
*Out:*
```

```

### EnemyInLocation

*Enemies/{LocationId}/{EnemyId}*

**Authorization** - Allow anonymous for all get, DM only for post

**Get** - All Enemies and their locations 

**Post** - Create new Enemy location by supplying: LocationId and EnemyId 

*Enemies/{LocationId}/{EnemyId}*

**Authorization** - Allow anonymous for all gets, DM only for put

**Get** - Location with the given id inside Enemy

**Put** - Update Location in Enemy 

**Samples**

*In:*
```

```
*Out:*
```

```