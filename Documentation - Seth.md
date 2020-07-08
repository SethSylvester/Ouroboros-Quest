# Description of the Problem
Name: Ouroboros Quest

Problem: 

## Evidence that includes:

## Pre-production completed
To be assessed as competent you will need to present the following evidence for assessment:

Created and completed project documentation submitted for review which includes:
Project management tools to be used
Production methodologies to be employed
Duties and responsibility of team members
Required assets
Key production milestones and what will be delivered at each milestone
Expected production costs including staff costs and facilities / software costs
Feedback has been sought, discussed and included, and pre-production has been approved by your teacher.

## Production completed
To be assessed as competent you are required to contribute towards the development of a body of work.
You will be assessed in two ways:

Observed participating successfully in the creation of a group project completed to a high level of polish by completing allocated task work including:
Working respectfully and effectively with others
Maintaining record keeping and task tracking
Regularly reporting production status
Submitting agreed upon deliverables for milestones that were set during pre-production

## Post-production completed
To be assessed as competent you will need to present the following evidence for assessment:

Post-mortem document created and submitted, developed to an industry acceptable standard that includes:
Critical review of the production including potential improvements for future productions, issues that arose during production and major challenges overcome during production
Present post-mortem results to peers


# Input information

* W - Moving Upwards
* S - Moving Downwards
* A - Moving Left
* D - Moving Right

E - Used to activate the teleporter

Mouse click is to attack

1 - Switch to your sword
2 - Switch to your axe
3 - Switch to the bow & arrow

# Design Documentation
System Architecture Description

![Flowchart](Flowchart.PNG)


## Type 'IslandGeneratorBehavior'
In charge of generating various islands with small individual changes between them.

---

#### Field spawnLocations
Type: List

Desc: A list of spawn locations for terrain obstacles.

---

#### Field largeTree
Type: Gameobject

Desc: Large trees to be placed in the scene

---

#### Field smallTree
Type: Gameobject

Desc: Small trees to be placed in the scene

---

#### Field bush
Type: Gameobject

Desc: Bushes to be placed in the scene, they slowdown the player.

---

#### Field Biomes
Type: Enum

Desc: An enum to determine the biome of the current island.

---

#### Field groundColor
Type: Color32

Desc: The color to set the ground as

---

#### Field DarkGreen
Type: Color32

Desc: A dark green color for the forest floor.

---

#### Method GenerateGrassLands

Desc: Generates the "grasslands" biome type for islands

---

## Type 'SlowBehavior'
Slows the player down on bushes

---

## Type 'TeleporterBehavior'
Teleports the player to the next island or boss arena.

---

#### Field canvas
Type: Gameobject

Desc: The canvas for the UI.

---

#### Field UIBehavior
Type: UiBehavior

Desc: Reference to the UIBehavior script.

---

## Type 'BossHealthbarBehavior'
A class to set up the bosses healthbar.

---

#### Field boss
Type: Gameobject

Desc: A reference to the boss

---

#### Field position
Type: Vector2

Desc: The position of the bosses healthbar on screen

---

#### Field backgroundPosition
Type: Vector2

Desc: The position for the backing of the healthbar

---

#### Field backgroundSize
Type: Vector2

Desc: The size of the background bar

---

#### Method DrawQuad 

Desc: Draws a rectangle.

---

## Type 'HostileAttackColliderBehavior'
The collider behavior on the enemy bosses projectiles to hurt the player.

---

## Type 'JesterBossBehavior'
The mastermind file for controlling the Jester boss and signalling it when to attack

---

#### Field hp
Type: int

Desc: Bosses health

---

#### Field attackTimerDefault
Type: float

Desc: The length of time that the boss attacks

---

#### Field VulnerabilityTimerDefault
Type: float

Desc: The timer for the vulnerability phase.

---

#### Field KnifeForkTimeDefault
Type: float

Desc: The timer for the knife fork attack

---

#### Field SuperWaveTimerDefault
Type: float

Desc: The timer inbetween waves for the super attack

---

#### Field attackLimit
Type: int

Desc: the limit for attacks before triggering the vulnerability phase.

---

#### Field canAttack
Type: bool

Desc: Tells the boss whether it can attack or not

---

#### Field hasAttack
Type: bool

Desc: Tells the boss to pick a new attack or not

---

#### Field vulnerable
Type: bool

Desc: If the boss is in its vulnerability phase.

---

#### Field waveOne
Type: bool

Desc: If the boss is in the first wave of the super wave attack.

---

#### Field waveTwo
Type: bool

Desc: If the boss is in the second wave of the super wave attack.

---

#### Field waveThree
Type: bool

Desc: If the boss is in the third wave of the super wave attack.

---

#### Field waveFour
Type: bool

Desc: If the boss is in the fourth wave of the super wave attack.

---

#### Field waveFive
Type: bool

Desc: If the boss is in the fifth wave of the super wave attack.

---

#### Field currentAttack
Type: Enum

Desc: The current attack the boss is doing

---

#### Field spreadShot
Type: Gameobject

Desc: Reference to the spreadshot gameobject

---

#### Field knifeFork
Type: Gameobject

Desc: Reference to the knifeFork gameobject

---

#### Field knifeShower
Type: Gameobject

Desc: Reference to the knifeShower gameobject

---

#### Field WaveOne
Type: Gameobject

Desc: Reference to the WaveOne gameobject

---

#### Field WaveTwo
Type: Gameobject

Desc: Reference to the WaveTwo gameobject

---

#### Field WaveFive
Type: Gameobject

Desc: Reference to the WaveFive gameobject

---

#### Field projectile1
Type: Gameobject

Desc: Reference to the first projectile gameobject for the knifeFork attack

---

#### Field projectile2
Type: Gameobject

Desc: Reference to the second projectile gameobject for the knifeFork attack

---

#### Field projectile3
Type: Gameobject

Desc: Reference to the third projectile gameobject for the knifeFork attack

---

#### Field projectile4
Type: Gameobject

Desc: Reference to the fourth projectile gameobject for the knifeFork attack

---

#### Field active1
Type: bool

Desc: Returns if the first projectile is active in the knifeFork attack

---

#### Field active2
Type: bool

Desc: Returns if the second projectile is active in the knifeFork attack

---

#### Field active3
Type: bool

Desc: Returns if the third projectile is active in the knifeFork attack

---

#### Field active4
Type: bool

Desc: Returns if the fourth projectile is active in the knifeFork attack

---

#### Field returning 
Type: bool

Desc: Tells if the projectiles are returning or not in the Knifefork attack

---

#### Method BossAttack

Desc: Tells the boss to attack with a switch statement.

---

#### Method Vulnerability

Desc: Handles the boss being vulnerable

---

#### Method AttackTimer

Desc: Ticks down the attack timer

---

#### Method SelectAttack

Desc: Selects a new attack for the boss

---

#### Method SuperAttackOne

Desc: The first super attack for the super attack wave

---

#### Method SuperAttackTwo

Desc: The second super attack for the super attack wave

---

#### Method SuperAttackThree

Desc: The third super attack for the super attack wave

---

#### Method SuperAttackFour

Desc: The fourth super attack for the super attack wave

---

#### Method SuperAttackFive

Desc: The fifth super attack for the super attack wave

---

#### Method KnifeFork

Desc: The KnifeFork attack of the jester boss

---

#### Method ResetKnifeFork

Desc: Resets the knife fork attack for future use.

---

#### Method TakeDamage

Desc: Tells the boss to take damage

---

#### Method Die

Desc: Kills the boss

---

#### Method GetHealth

Desc: Returns its HP

---

## Type KnifeForkProjectileBehavior
The Behavior of the KnifeForks projectile

---

#### Field timeDefault
Type: float

Desc: The default value for the return timer and forward timer

---

#### Field playerPos
Type: Vector3

Desc: The players position

---

#### Field parentPos
Type: Vector3

Desc: The jester bosses position

---

#### Field speedDefault
Type: float

Desc: float for the speed of the bullets

---

#### Field jester
Type: Gameobject

Desc: A reference to the jester

---

#### Field Player
Type: Gameobject

Desc: A reference to the player

---

#### Field Movement
Type: Vector3

Desc: The movement vectors that allow bullet to move.

---

#### Field _controller
Type: CharacterController

Desc: A reference to the character controller the bullet has

---

#### Field hasPlayerPos
Type: bool

Desc: tells if the bullet has the players position

---

#### Method GetPlayerPos

Desc: Gets the players position

---

#### Method MoveBulletForward

Desc: Moves the bullet forward

---

#### Method ReturnBullet

Desc: Returns the bullet to the boss

---

#### Method ResetBullet

Desc: Resets the bullets rotation and deactivates it.

---

## Type KnifeShowerBehavior
Behavior for the knifeshower attack.

---

#### Field player
Type: Gameobject

Desc: A reference to the player

---

#### Field playerPos
Type: Vector3

Desc: The players position

---

## Type ProjectileBehavior
Behavior class for most projectiles.

---

#### Field speed
Type: float

Desc: The speed of the projectile.

---

#### Field _movement
Type: vector3

Desc: The vector3 that controls the projectiles movement

---

#### Field _controller
Type: CharacterController

Desc: The character controller for the projectile

---

## Type ProjectileSpawnBehavior
The spawner for projectiles for several Jester attacks

---

#### Field SpawnedEnemy
Type: Gameobject

Desc: The enemy (projectile) to spawn

---

#### Field SpawnTimer
Type: float

Desc: The time inbetween projectile spawners.

---

#### Field _currentSpawnPoint
Type: Transform

Desc: Where the projectiles spawn

---

#### Field spawnedAmount
Type: int

Desc: Amount of bullets spawned

---

## Type SingleProjectileSpawnerBehavior
Spawns a single projectile on activation.

---

## Type NavigateMenuBehavior
The controller for the menu.

---

#### Field fullscreen
Type: bool

Desc: A bool to toggle fullscreen

---

#### Field menus
Type: List

Desc: A list of menus.

---

#### Field volumeSlider
Type: Slider

Desc: controls the game volume

---

#### Field resolutionDropdown
Type: Dropdown

Desc: A dropdown menu of resolutions.

---

#### Field fullscreenToggle
Type: toggle

Desc: Toggles the fullscreen bool

---

#### Method MainMenu

Desc: Activates the main menu

---

#### Method OptionsMenu

Desc: Activates the options menu

---

#### Method SetResolution

Desc: Sets the screen resolution

---

#### Method SetVolume

Desc: Sets the audio volume

---

#### Method FullScreenToggle

Desc: Toggles fullscreen

---

#### Method ApplyChanges

Desc: Applies changes from the options

---

#### Method Quit

Desc: Exits application

---

## Type StartButtonBehavior
Loads in the first scene of the game.

---

## Type AttackColiderBehavior
The attack collider for the players weapons

---

#### Method DestroyArrow

Desc: Destroys arrows.

---

## Type PlayerAttackBehavior
The controller for letting the player attack.

---

#### Field attackDelay
Type: float

Desc: The players delay for when they can attack

---

#### Field HitboxSpawnTimeDefault
Type: float

Desc: The time that the hitbox lasts for

---

#### Field canAttack
Type: bool

Desc: Tells the player if they can attack

---

#### Field weaponOut
Type: bool

Desc: Tells if the player has a weapon model equipped

---

#### Field swordHitbox
Type: GameObject

Desc: The Sword hitbox

---

#### Field axeHitbox
Type: GameObject

Desc: The axe hitbox

---

#### Field ArrowSpawner
Type: GameObject

Desc: The arrow spawning object

---

#### Field Arrow
Type: GameObject

Desc: A reference to the arrow prefab

---

#### Field swordModel
Type: Gameobject

Desc: The swords model

---

#### Field axeModel
Type: Gameobject

Desc: The axes model

---

#### Field bowModel
Type: GameObject

Desc: The bow & arrows model

---

#### Method Attack

Desc: The players main attack function.

---

#### Method WeaponTimer

Desc: Ticks down and resets weapon timers for delays.

---

#### Method CheckAttack

Desc: Checks if the player can attack

---

#### Method SwitchWeaponModel

Desc: Switches the weapon model.

---

## Type PlayerMovementBehavior
The big class determining how the player moves.

---

#### Field gravityDefault
Type: float

Desc: The default value for the gravity applied to the player

---

#### Field _jumpTimer
Type: float

Desc: The timer for the delay inbetween player jumps

---

#### Field _gravity 
Type: float

Desc: The current amount of gravity being applied to the player

---

#### Field groundDistance
Type: float

Desc: The distacne between the ground and the player needed to be considered grounded

---

#### Field jumping
Type: bool

Desc: Tells if the players jumping

---

#### Field _verticalGravity
Type: vector3

Desc: The gravities vector3

---

#### Field _movement
Type: Vector3

Desc: The vector3 for moving the player

---

#### Field _controller
Type: CharacterController

Desc: The character controller.

---

#### Method Jump

Desc: The method that lets the player jump

---

#### Method GoUp

Desc: Moves the player up

---

#### Method GoDown

Desc: Moves the player down

---

#### Method GoLeft

Desc: Moves the player left

---

#### Method GoesRight

Desc: Moves the player to the right

---

#### Method IsGrounded

Desc: Raycasts to the ground to see if the player is grounded

---

#### Method FaceDirection

Desc: Faces the direction of the mouse

---

#### Method Gravity

Desc: Applies gravity to the player

---

#### Method Teleport

Desc: Teleports to the mouse location

---

#### Method GetInput

Desc: Gets the input from the keyboard and mouse

---

## Type PlayerScriptBehavior
Contains the players variables such as HP and speed

---

#### Field hp
Type: int

Desc: The players health.

---

#### Field shards
Type: int

Desc: The amount of shards the players collected

---

#### Field damage
Type: int

Desc: The amount of damage the player is doing

---

#### Field attackDelay
Type: float

Desc: The delay between attacks

---

#### Field Speed
Type: float

Desc: The players speed

---

#### Field normalSpeed
Type: float

Desc: Default speed

---

#### Field slowedSpeed
Type: float

Desc: The players speed cut in half

---

#### Field weapon
Type: Enum

Desc: The players weapon that they have equipped

---

#### Field invul
Type: bool

Desc: A bool to determine if the player is invulnerable.

---

#### Field IFramesDefault
Type: float

Desc: the default timer for Iframes

---

#### Field playerAttack
Type: PlayerAttackBehavior

Desc: A reference to the PlayerAttackBehavior

---

#### Method TakeDamage

Desc: Damages the player and activates IFrames

---

#### Method Heal

Desc: Heals the player  

---

#### Method Die

Desc: Kills the player and disallows them to move or attack

---

#### Method SwitchWeapon

Desc: Switches the currently held weapon and weapon model

---


## Type UIBehavior
The behavior file for the UI.

---

#### Field health1
Type: RawImage

Desc: The first health picture

---

#### Field health2
Type: RawImage

Desc: The second health picture

---

#### Field health3
Type: RawImage

Desc: The third health picture

---

#### Field HeartFull
Type: Texture

Desc: A full heart

---

#### Field HeartEmpty
Type: Texture

Desc: An empty heart

---

#### Field shards
Type: Text

Desc: A text display for how many shards you have

---

#### Field BossButtons
Type: Gameobject

Desc: The teleporter buttons to teleport between islands

---

#### Method DisplayHealth

Desc: Displays and updates the players health

---

#### Method TeleporterButtons

Desc: Activates the teleporter buttons

---

#### Method TeleportNewIsland

Desc: Teleports to a new island and loads a new scene

---

#### Method TeleportBossIsland

Desc: Teleports to the boss island and loads the boss scene

---