# Crypts and Coders
API hosted at: *dummy.com*

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


### Locations
*/Locations*

**Authorization** - GM only

**Get** - All Locations and their information (characters and enemies in location)

**Post** - Create new location by supplying: Name and Description


*/Locations/{Name}* 

**Authorization** - Users can get their current location, only GM for other operations

**Get** - Location with the given name and their associated information.

**Put** - Update location info

### Enemies
*/Enemies*

**Authorization** - GM only

**Get** - All Enemies and their information

**Post** - Create new enemy by supplying: Name and Description


*/Enemies/{Name}* 

**Authorization** - Users can get enemies in their current location, only GM for other operations

**Get** - Enemy with the given name and their associated information.

**Put** - Update enemy info

### Items
*/Items*

**Authorization** - Allow anonymous for all gets, DM only for post

**Get** - All Items and their information

**Post** - Create new item by supplying: Name and Value


*/Items/{id}* 

**Authorization** - Allow anonymous for all gets, DM only for put

**Get** - Item with the given id and it's associated information.

**Put** - Update item info


### Weapons
*/Weapons*

**Authorization** - Allow anonymous for all get, DM only for post

**Get** - All Weapon items and their information

**Post** - Create new weapon by supplying: Name and type

*/Weapons/{id}* 

**Authorization** - Allow anonymous for all gets, DM only for put

**Get** - Weapon with the given id and it's associated information.

**Put** - Update weapon info
