DUNGEON CRAWLER

A console-based dungeon crawler game developed in C# as an object-oriented programming project.

DESCRIPTION

The player explores a randomly generated dungeon, fights different enemies, collects loot, gains experience, levels up, manages equipment, trades items in a shop, and can save and load their progress.

FEATURES

* Console-based gameplay
* Turn-based combat system
* Multiple enemy types:

  * Goblin
  * Skeleton
  * Orc
  * Dungeon Boss
* Enemy special attacks and abilities
* Experience and leveling system
* Health and healing system
* Weapon and armor equipment
* Inventory system
* Gold system
* Shop with buying and selling
* Random loot system
* Randomly generated dungeons
* Different room types:

  * Combat Room
  * Healing Room
  * Treasure Room
  * Boss Room
* Save and Load system using JSON
* Unit tests using xUnit



GAMEPLAY

The player starts with basic stats and a limited amount of gold.

The dungeon consists of multiple randomly generated rooms. During exploration, the player can encounter enemies, healing rooms, or treasure.

Combat is turn-based. The player can:

1. Attack
2. Use an item
3. Run from combat

Defeating enemies rewards the player with experience and gold, with a chance of receiving additional loot.

As the player gains experience, they level up and become stronger.

The final room contains the Dungeon Boss.



CHARACTER SYSTEM

The project uses a base Character class for common character functionality.

Character
|
+-- Player
|
+-- Enemy
|
+-- Goblin
+-- Skeleton
+-- Orc
+-- Boss

Characters have:

* Health
* Max Health
* Attack Power
* Defense
* Level

The Player class extends Character and adds:

* Experience
* Gold
* Inventory
* Equipped Weapon
* Equipped Armor



ITEM SYSTEM

Items are represented using an abstract Item base class.

Item
|
+-- Potion
+-- Weapon
+-- Armor

Each item has:

* Name
* Description
* Rarity
* Price
* Consumable status

Weapons increase attack power, armor increases defense, and potions restore health.



RARITY SYSTEM

Items can have different rarities:

* Common
* Uncommon
* Rare
* Epic
* Legendary



COMBAT SYSTEM

Combat is handled by the CombatSystem class.

Each character can attack another character, while different enemies can override the default attack behavior.

Examples:

* Goblins can perform a sneaky attack.
* Skeletons can perform a Bone Strike.
* Orcs can sometimes reduce incoming damage.
* The Boss can perform a devastating attack.

This demonstrates polymorphism through overridden methods such as Attack() and TakeDamage().



DUNGEON SYSTEM

Dungeons are generated dynamically using DungeonGenerator.

A dungeon contains several rooms followed by a final Boss Room.

Example:

Combat Room
Healing Room
Treasure Room
Combat Room
Boss Room

The generated room types can vary between dungeon runs.



SHOP SYSTEM

The player can visit the shop from the main menu.

The shop supports:

* Buying items
* Selling items
* Gold management

Items are sold for 50% of their original price.



LOOT SYSTEM

Enemies can drop random loot after being defeated.

Different enemies have different loot tables and chances.

Stronger enemies can drop better equipment, while the Boss can drop a Legendary Sword.



SAVE SYSTEM

The game supports saving and loading player progress.

The following information is stored:

* Player name
* Health
* Max Health
* Base attack
* Base defense
* Level
* Experience
* Gold
* Inventory
* Equipped weapon
* Equipped armor

Save data is stored in:

savegame.json



OBJECT-ORIENTED PROGRAMMING

Encapsulation

Important properties use controlled access through private or protected setters.

Example:

public int Gold { get; private set; }

Gold can only be changed through methods such as AddGold() and SpendGold().



Inheritance

Common functionality is placed in base classes.

Character
|
+-- Player
+-- Enemy

Item
|
+-- Potion
+-- Weapon
+-- Armor



Polymorphism

Enemy classes override behavior from the base classes.

Example:

public override AttackResult Attack(Character target)

This allows different enemies to have different attack behavior while still being treated as Character or Enemy objects.



Abstraction

Abstract classes such as Item and Room define common functionality while allowing derived classes to implement their own behavior.



PROJECT STRUCTURE

DungeonCrawler
|
+-- DungeonCrawler.Core
|   |
|   +-- Characters
|   |   +-- Character.cs
|   |   +-- Player.cs
|   |   +-- Enemy.cs
|   |   +-- Goblin.cs
|   |   +-- Skeleton.cs
|   |   +-- Orc.cs
|   |   +-- Boss.cs
|   |
|   +-- Items
|   |   +-- Item.cs
|   |   +-- Potion.cs
|   |   +-- Weapon.cs
|   |   +-- Armor.cs
|   |   +-- Inventory.cs
|   |
|   +-- Combat
|   |   +-- CombatSystem.cs
|   |   +-- AttackResult.cs
|   |   +-- CombatResult.cs
|   |
|   +-- DungeonLogic
|   |   +-- Dungeon.cs
|   |   +-- Room.cs
|   |   +-- CombatRoom.cs
|   |   +-- HealingRoom.cs
|   |   +-- TreasureRoom.cs
|   |   +-- BossRoom.cs
|   |   +-- DungeonGenerator.cs
|   |
|   +-- LootLogic
|   |   +-- LootGenerator.cs
|   |
|   +-- ShopLogic
|   |   +-- Shop.cs
|   |
|   +-- SaveLogic
|   |   +-- SaveSystem.cs
|   |
|   +-- Game
|       +-- Game.cs
|
+-- DungeonCrawler.Tests
+-- CharacterTests.cs
+-- PlayerTests.cs
+-- InventoryTests.cs
+-- ShopTests.cs
+-- CombatTests.cs
+-- DungeonTests.cs
+-- LootGeneratorTests.cs
+-- EnemyTests.cs
+-- SaveSystemTests.cs



TESTING

The project includes automated unit tests using xUnit.

The tests cover:

* Character stats
* Damage calculation
* Healing
* Player leveling
* Experience
* Gold
* Equipment
* Inventory operations
* Shop transactions
* Combat calculations
* Dungeon generation
* Enemy properties
* Loot generation
* Save and Load functionality

Current test suite:

67 tests
67 passed
0 failed



TECHNOLOGIES

* C#
* .NET
* Visual Studio 2022
* xUnit
* JSON serialization
* Object-Oriented Programming



HOW TO RUN

1. Clone the repository.
2. Open the solution in Visual Studio 2022.
3. Build the solution.
4. Run the DungeonCrawler project.
5. Follow the instructions in the console.

To run the tests:

dotnet test

To generate code coverage:

dotnet test DungeonCrawler.sln --collect:"XPlat Code Coverage"



AUTHOR

Filip Baranjek
FERIT Osijek
Computer Science / Software Engineering



