# Granjure
#### Video Demo:https://youtu.be/Ef6tDe1RkGg
#### Description: A relaxing farming game built in Unity(Version 2018.4.28f1) with C# where you play as a small animal on a farm, trying to sell your harvest to the people in the small town.
## Abstract
Granjure is a small farming rpg game where you play as a cat. You have to forage for mushrooms and grow crops to make a living. As a small and defenseless cat you need to brave the sometimes dangerous forest in order to sell your goods. The game consists of three main sections: the farm, the forest, and the town. Your small home is a cozy space you can rest in, and is accessible from your farm, since your home is located within your farm. To start up the game, upon seeing the title screen you click 'Enter' to begin your session. Since this is your first time entering your farm, an instruction window appears, you click 'Enter' to close this one time pop-up window. To control your cat farmer, you walk using the arrow keys. To use the watering can press the 'G' key. To use the harvesting tool press the 'H' key. These tools are only useful when working on your farmland.
Your day consists of growing carrots and collecting your harvest on your farm. by going up to your sprouts and watering them with 'G', and harvesting them by going up to your carrot and harvesting with 'H'. Once your crop has been harvested, the sprout is no longer a growing carrot but now a collectible veggie that can be added to your pocket by colliding with it. In order to sell your harvest in town, you need to take the path through the forest.
The forest path can be treacherous if you are not careful. There are a variety of mushrooms you can forage in the forest. To forage, you collide with the mushroom you wish to collect. These can be sold in town to particular townsfolk. However, due to the bountiful mushrooms present, there is an evil red chicken who protects the forest and its mushrooms. This enemy is angry and protective of its food source, and will throw rocks to the cat who dares to enter its realm. If these rocks hit you, the player loader will be destroyed since the cat has died, and the Game Over scene will be triggered upon this death. On the Game Over scene, you can see how much money your cat character accumulated during the playthrough, and have the option to return to the Start scene by pressing 'Enter'. If with some skill, and some luck, you manage to survive the forest, and exit through the path towards the town, you are closer to a great payday!
Once in town, there are three houses in which you can find other cats. Each has a food preference and will buy the items you have collected. This helps the cats town survive since they now have a food source, and you get some coins! The price they are willing to pay reflects the quality of the food. Farm grown carrots are valued higher over foraged mushrooms. Also, good mushrooms fetch a higher price than sour/questionable mushrooms. You can continue to help the town and collect your riches, so long as you stay alive.
## Code
### CanvasUI
Handles the UI Text for the amount of coins a player accumulates.
### EnemyController
Controls the enemy present in the forest: the evil red chicken who is throwing rocks at the player. This is because we need an enemy that creates a way for the player to lose the game. By getting hit by the rock the chicken throws, it will be gameover. To simulate throwing the rock, a bullet prefab is instantiated at the location of the chicken, and "thrown" in the direction of the player. The bullet objects are "thrown" at a constant speed, continously starting when the player enters the area. Each new bullet is instantiated at a shoot interval, making it somewhat possible for the player to manuver around the scene. 
### EnterExitHouse
Handles scene switching based on what door the player goes through. Either the outside door visible on the farm which loads scene HouseScene, or the inside door visible in the house which loads scene FarmScene. It enables the player to use the door of the house as intended by using a collider trigger, and then utilizing portals to determine at which coordinates the player should be in the loaded scene.
### ForageMushrooms
When player collides with mushrooms, this script determines which type of mushroom it is, adds it to the player's pocket, and destroys the mushroom gameobject since it was picked up. This script is attached to both mushroom prefabs, and upon foraging there is an audio clip that is played.
### GameOverState
When player dies, the coins from their pocket(which were saved in PlayerPrefs) will be shown on the GameOver scene. If player chooses to continue by hitting the Enter/Return key, the previous game's persisting objects will be destroyed, and Start scene will be loaded. 
### GrowCarrot
This script handles growing the carrot through its 4 stages, as well as the first portion of harvesting. It is attached to each carrot sprout gameobject in FarmScene (Carrot 1A,...Carrot 4D).
### HarvestCarrot
Once the carrot is visible as a veggie that was harvested(no longer in the ground), the item can be picked up by colliding with it. Upon collection, there is an audio clip sound effect that is played. This script that is attached to the carrot prefeb handles the collision, adding the carrot to the pocket, and destroying the carrot gameobject.
### HouseDialogPop
Handles the UI text reactions to player colliding with items in the house. When the user hits the Enter/Return key the HouseDialogPopup PreFab gameobject will be destroyed.
### HouseReaction
Handles the collisions with items in the house. Sends the item name of the object player collided with, and calls to update the dialog. This will fill in the dialog : "It's just (item)."
### MenuState
This script handles the menu state, when the player can see the instruction menu. Player should only be clicking Enter to close the menu, so the openingstate scene containing the menu is unloaded. (It is called opening state since we only want to show it once upon opening the game, not every time we go back to the farm.)
### Mushroom
Holds the Mushroom class definiton and enum MushroomType that determines if it is a good or bad mushroom. This script is attached to both mushroom prefabs: GoodMushroom and BadMushroom.
### MushroomSpawner
Each time the player enters the ForestScene the MushroomSpawner gameobject uses the MushroomSpawner script to spawn mushrooms in all tiles not used in the 2D Tilemap. In the inspector the TreeTops tilemap, the two mushroom prefabs are attached within the script's component, and the counts for the mushrooms are set as 5 each. This means that 5 of each mushroom will be spawned upon entry into the scene based on the walkable area available for the player if the tile is null(unused) in that tilemap.
### PathToFarm
Handles the trigger collision and asyncronously scene loading of the FarmScene upon exiting the ForestScene through the FarmPath. Before leaving upon switching scenes, the PathSpawnPoint within FarmScene is found so that the player spawns at that location when starting up the scene.
### PathToForest
Handles the trigger collision and asyncronously scene loading of the ForestScene upon exiting the FarmScene through the PathExit. Before leaving upon switching scenes, the FarmEntrance within ForestScene is found so that the player spawns at that location when starting up the scene.
### PathToTown
Handles the trigger collision and asyncronously scene loading of the TownScene upon exiting the ForestScene through the TownPath. Before leaving upon switching scenes, the ForestPath within TownScene is found so that the player spawns at that location when starting up the scene.
### PathTownToForest
Handles the trigger collision and asyncronously scene loading of the ForestScene upon exiting the TownScene through the ForestPath. Before leaving upon switching scenes, the TownEntrance within ForestScene is found so that the player spawns at that location when starting up the scene.
### PersistingObjects
Handles the Prefab that contains: Player and a Canvas with the PocketView and coin count. Throughout the game there should only be a single instance of these objects, they are held within a prefab of the same name. Since they should persist through different scenes, DontDestroyOnLoad is called for the gameobject.
### PersistingObjectsSpawner
Spawns the PersistingObjects prefab, is attached to a empty gameobject called "PlayerLoader" within the FarmScene.
### PlayerManager
The PlayerManager allows the player to move around, do different actions, and change the animation of the player character accordingly. Player movement is determined by position change(arrow keys are used to move player) and speed(a set value of 6, that can only be altered in the game object inspector). Apart from walking and idle states, watering and harvesting states are also defined within PlayerManager. The script also contains an enum for defining the PlayerState. If the Player gameobject is hit with a bullet projectile(visually it will be a rock thrown from the chicken), the whole PlayerLoader(Player's Parent gameobject) will be destroyed, and user will get a GameOver.
### Pocket
Keeps counts of items gathered and sold, and coins.
### PocketUI
Connects to Pocket script, updates UI Texts for counts of items in pocket and coins. Coins are saved to PlayerPrefs.
### ProjectileCollision
When the rock projectile "bulletObj" prefab collides with anything the projectile is destroyed.
### SellingBadMushroomState
Connects to Pocket script, when the player collides with the NPC that likes Bad Mushrooms, the bad mushrooms from the pocket are sold for coins. Pocket is called to remove those mushrooms.
### SellingCarrotState
Connects to Pocket script, when the player collides with the NPC that likes Carrots, the carrots from the pocket are sold for coins. Pocket is called to remove those carrots.
### SellingGoodMushroomState
Connects to Pocket script, when the player collides with the NPC that likes Good Mushrooms, the good mushrooms from the pocket are sold for coins. Pocket is called to remove those mushrooms.
### StartState
This script handles the opening Start Scene. While in this scene, to start the game user hits return. When Enter/Return is pressed, FarmScene and OpeningScene are loaded asyncronously. The later is loaded additively since the opening menu will be a pop up scene above the FarmScene.
## How to Run Game
1. Download project folder.
2. Open project in Unity (Version 2018.4.28f1 was used to build this game.)
3. Click Play button.
## Assumptions
### Growing Carrots
Each crop must be watered once per collision. Continuous watering without moving will not register since it needs to be triggered by a collision. Best practice is to water any number distinct sprouts, each to state 1, then each to state 2, etc.
### Upon Any Collision with a Carrot Crop
It is assumed Player will complete an action: either Water or Harvest(if crop at last state); not completing an action will leave the crop you collided with "active" until you complete such action on it.
## Design
Granjure (Granja: spanish for farm, Adventure; also Grand, Journey) The grand farming adventure! The color palette is soft and light throughout which alludes to the coziness and calm concept of this game. The colors get deeper while in the forest which allude to the dangers present: the evil chicken that guards the forest and its mushrooms.
### Map
The world of Granjure consists of 4 locations: Player's Farm, Player's House, The Forest, and The Town. The farm is connected by scene switches to both the house and the forest, the house only connects to the farm, the forest connects to both the farm and the town, and the town only connects to the forest. These are in the visual form of either paths or doors the player goes through in order to activate a scene load.
### Graphics
The aspect ratio used when designing this game: 16:9.
The layouts of the scenes: FarmScene, ForestScene, House Scene, Start, and TownScene, were built using Tilemaps and TilePalettes.
The layouts of the scenes: GameOver, OpeningState, were made using a UI Canvas, UI Text and UI Images.
Graphics used in the creation of the player animations, UI images, objects, and tilemap of the landscape were purchased through license from an artist.
#### Sprout Lands asset pack.
 - Made by: Cup Nooble https://www.instagram.com/cup_nooble/?hl=en , https://cupnooble.carrd.co/
 - Link to the pack: https://cupnooble.itch.io/sprout-lands-asset-pack
 - License - Premium Pack
  - You can modify the assets.
  - You can not redistribute or resale, even if modified.
  - You can use these assets in non-commercial and commercial projects. [No NFT's]
  ( Credit : (Cup Nooble) )
#### Sprout Lands UI asset pack.
 - Made by: Cup Nooble https://www.instagram.com/cup_nooble/?hl=en , https://cupnooble.carrd.co/
 - Link to the first pack in the Sprout Lands series: https://cupnooble.itch.io/sprout-lands-asset-pack 
 - License - Premium  Pack
  - You can modify the assets.
  - You can not redistribute or resale, even if modified.
  - You can use these assets in non-commercial and commercial projects. [No NFT's]
  - Note from Artist:( If you want to make something commercial with these sprites contact me or buy the Premium version )
  ( Credit : (Cup Nooble) )
### Sounds
In order to make the game more immersive, each scene has its own audio. Some actions also have their own sound effects, giving more life to the character.
#### 8-Bit Sound Effect Pack (Vol. 001)
 - https://opengameart.org/content/8-bit-sound-effect-pack-vol-001
 - License: Public Domain (CC0)
 - Sound Effects were used as provided by @Shades, and were not altered.
 You do not need permission to use for non commercial / commercial uses, just please credit me as @Shades https://soundcloud.com/noshades

The pack contains (46 wav files) :
5 coin sound effects
3 exit sound effects
5 explosion sound effects
3 flying sound effects
6 hit sound effects
4 jump sound effects
3 powerup sound effects
3 shoot sound effects
4 talk sound effects
3 error sound effects
#### 8-Bit Sound Effects Library
 - https://opengameart.org/content/8-bit-sound-effects-library
 - Copyright/Attribution Notice: Attribute Little Robot Sound Factory www.littlerobotsoundfactory.com
 - License: Creative Commons Attribution-ShareAlike 4.0 International (CC BY-SA 4.0) https://creativecommons.org/licenses/by-sa/4.0/
 - Sound Effects were used as provided by Little Robot Sound Factory, and were not altered.
#### Cozy Sim Music Pack (Tiny Pack)
##### Track List:

| Name                  | BPM | Duration | Available on: |
| --------------------- | --- | -------- | ------------- |
| 1 - New Life          | 130 | 01:58    | Tiny Pack     |
| 2 - Cafe Avenue       | 80  | 02:48    | Tiny Pack     |
| 3 - Fireflies         | 60  | 03:22    | Tiny Pack     |
| 4 - Working Time      | 52  | 03:50    | Tiny Pack     |
| 5 - Frog Pond         | 69  | 01:51    | Tiny Pack     |
| 6 - Nap               | 50  | 04:43    | Grand Pack    |
| 7 - Rain Shower       | 84  | 03:37    | Grand Pack    |
| 8 - Build Mode        | 92  | 02:49    | Grand Pack    |
| 9 - Aloes Garden      | 72  | 02:43    | Grand Pack    |
| 10 - Learning To Play | 124 | 03:07    | Grand Pack    |
| 11 - Winter Breeze    | 84  | 02:51    | Grand Pack    |
| 12 - Carnival Ends    | 123 | 03:07    | Grand Pack    |
| 13 - The Botanist     | 68  | 02:47    | Grand Pack    |
| 14 - Flower Shop      | 83  | 03:02    | Grand Pack    |
| 15 - Feeling The Sun  | 58  | 03:51    | Grand Pack    |
| 16 - Home Workshop    | 84  | 04:11    | Grand Pack    | 


Total music duration: 00:50:43

##### Stingers

| Name                | Duration | Available on: |
| ------------------- | -------- | ------------- |
| 17 - New Season     | 00:09    | Tiny Pack     |
| 18 - New Customer   | 00:04    | Tiny Pack     |
| 19 - Skill Learned! | 00:02    | Grand Pack    |
| 20 - Work Done      | 00:05    | Grand Pack    |
| 21 - Night Time     | 00:04    | Grand Pack    |
| 22 - Day Time       | 00:05    | Grand Pack    |
| 23 - Surprise Gift! | 00:05    | Grand Pack    |
| 24 - Too Late!      | 00:03    | Tiny Pack     | 
| 25 - A Bad Day      | 00:05    | Grand Pack    |


##### License

Cozy Sim Music Pack

Created/distributed by Rest! (https://rest--vgmusic.weebly.com/)
Creation date: 25-07-2023

	License: Creative Commons Attribution-ShareAlike 4.0 International (CC BY-SA 4.0)
	https://creativecommons.org/licenses/by-sa/4.0/

	This content is free to use in personal, educational and commercial projects.

	Support by crediting Rest! https://rest--vgmusic.weebly.com/

	Twitter and Bandcamp:
	https://twitter.com/PkRichar
	https://rest--vgmusic.bandcamp.com/follow_me