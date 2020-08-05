# Routes

- [AccountController Routes](#account)
- [CharactersController Routes]()
- [CharacterStatsController Routes]() 
- [EnemiesController Routes]()
- [ItemsController Routes]()
- [LocationsController Routes]()
- [StatsController Routes]()
- [WeaponsController Routes](#weapons)


There are two levels of privelages, or 'roles'; GameMaster and Player. A GameMaster has no limitations
when requesting data through the routes. A Player, however, is limited in what they have 
access to.

### AccountController
# <a name="account"></a>

**Register()** - POST

The GameMaster role has the ability to register new GameMaster roles as well as player
roles.

```JSON
Access level -> All users
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

{
    "userName": "NoobMaster69",
    "password": "@Test123!"
}

```

### CharactersController

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




```

**PostCharacter()** - POST

Creates a new character. Once entered, it will return the JSON data in the same manner as 'GetCharacter()' does.

```JSON
Access level -> All users
api/characters/

{
    "name": "Noobie4Life",
    "Species": "Human",
    "Class": "Thief",
    "WeaponId": 1,
    "LocationId": 1
}
```

### CharacterStatsController

### EnemiesController

### ItemsController

### LocationsController

### StatsController

### WeaponsController
# <a name="weapons"></a>