# Routes

- [AccountController Routes](#account)
- [CharactersController Routes](#characters)
- [CharacterStatsController Routes](#character-stats) 
- [EnemiesController Routes](#enemies)
- [ItemsController Routes](#items)
- [LocationsController Routes](#locations)
- [StatsController Routes](#stats)
- [WeaponsController Routes](#weapons)


There are two levels of privileges, or 'roles'; GameMaster and Player. A GameMaster has no limitations
when requesting data through the routes. A Player, however, is limited in what they have 
access to.

### AccountController
# <a name="account"></a>

**Register()** - POST

The GameMaster role has the ability to register new GameMaster roles as well as player
roles.

```JSON
Access level -> Game master
api/account/register

{
    "userName": "NoobMaster69",
    "password": "@Test123!",
    "email": "MrNoob@aol.com",
    "role": "player"
}
```

**Login()** - POST

Once an account has been registered, that user can then login to their account utilizing 
their username and password. Once entered, a JWT token will be returned.

```JSON
api/account/login
Access level -> All users

{
    "userName": "NoobMaster69",
    "password": "@Test123!"
}

```

### CharactersController
# <a name="characters"></a>


**GetCharacters()** - GET

Retrieves a list of all the characters within the database.

```JSON
Access level -> Game master
api/characters
[
    {
        "id": 1,
        "name": "Galdifor",
        "species": "Elf",
        "class": "Thief",
        "weaponId": 1,
        "weapon": {
            "id": 1,
            "name": "Claymore",
            "type": "Close Range",
            "baseDamage": 15
        },
        "locationId": 1,
        "currentLocation": {
            "id": 1,
            "name": "Faldor",
            "description": "Occupied by the forces of evil, Faldor consists of open, hilly plains that separate it's eastern border with towering mountains.",
            "enemies": [
                {
                    "id": 1,
                    "abilities": "Slash",
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
                    "name": "Health Potion",
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
                    "name": "Strength",
                    "id": 1
                }
            },
            {
                "statId": 2,
                "characterId": 1,
                "level": 0,
                "stat": {
                    "name": "Cunning",
                    "id": 2
                }
            }
        ],
        "userName": "userName"
    },
    // next character
]
```

**GetCharacter()** - GET

Retrieves a single characters based on the Id. Players can only access their own characters.

```JSON
Access level -> All users
api/characters/{id}
// output is same as GetCharacters(), only singular
```

**PostCharacter()** - POST

Creates a new character. Once entered, it will return the JSON data in the same manner as 'GetCharacter()' does.

```JSON
Access level -> All users
api/characters/

// INPUT
{
    "name": "Noobie4Life",
    "Species": "Human",
    "Class": "Thief",
    "WeaponId": 1,
    "LocationId": 1
}

// OUTPUT
{
    "id": 4,
    "name": "Noobie4Life",
    "species": "Human",
    "class": "Thief",
    "weaponId": 1,
    "weapon": {
        "id": 1,
        "name": "Claymore",
        "type": "Close Range",
        "baseDamage": 15
    },
    "locationId": 1,
    "currentLocation": {
        "id": 1,
        "name": "Faldor",
        "description": "Occupied by the forces of evil, Faldor consists of open, hilly plains that separate it's eastern border with towering mountains.",
        "enemies": [
            {
                "id": 1,
                "abilities": "Slash",
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
    "inventory": null,
    "statSheet": null,
    "userName": "NoobMaster69"
}
```

**DeleteCharacter()** - DELETE

**AddItemTOInventory()** - POST

**DeleteItemFrom Inventory()** - DELETE

### CharacterStatsController
# <a name="#character-stats"></a>

**GetStatSheet()** - GET

**GetCharacterStat()** - GET

**PutCharacterStat**() - PUT

**PostCharacterStat**() - POST

**DeleteCharacterStat**() - DELETE

### EnemiesController
# <a name="enemies"></a>

**GetEnemies()** - GET

**GetEnemy()** - GET

**PutEnemy()** - PUT

**PostEnemy() ** - POST

**DeleteEnemy()** - DELETE

### ItemsController
# <a name="items"></a>

**GetItem()** - GET

**GetItems()** - GET

**PutItem()** - PUT

**PostItem()** - POST

**DeleteItem()** - DELETE

### LocationsController
# <a name="locations"></a>

**GetLocations()** - GET

**GetLocation()** - GET

**PutLocation()** - PUT

**PostLocation()** - POST

**DeleteLocation()** - DELETE

### StatsController
# <a name="stats"></a>

**GetStats()** - GET

**GetStat()** - GET

**PutStat()** - PUT

**PostStat()** - POST

**DeleteStat()** - DELETE

### WeaponsController
# <a name="weapons"></a>

**GetWeapons()** - GET

**GetWeapon()** - GET

**PutWeapon()** - PUT

**PostWeapon()** - POST

**DeleteWeapon()** - DELETE