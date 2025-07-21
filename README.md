## 🎮 Game Concept

**Tawasol Test** is an endless runner game where players control a character that automatically moves forward while navigating through obstacles and collecting coins. The game features a simple yet engaging gameplay loop with increasing difficulty over time.

## 🎯 Core Mechanics

### Player Controls
- **Jump**: Press `Space` or `Left Mouse Button` to make the player jump over obstacles
- **Horizontal Movement**: Use `A/D` keys or `Left/Right Arrow Keys` to move the player left and right
- **Movement Constraints**: Player movement is clamped between -2 and +2 on the X-axis to keep gameplay within bounds


## 🛠️ Technical Implementation

### Core Scripts

#### `PlayerControll.cs`
- Handles player input (jump, horizontal movement)
- Manages grounding state and physics
- Collision detection for obstacles and coins
- Remote player synchronization support

#### `GameManager.cs`
- Singleton pattern for global game state
- Score management and progression
- Game over and reset functionality
- Coordinates between different game systems

#### `LevelSpawner.cs`
- Object pooling system for obstacles
- Continuous obstacle spawning with spacing
- Progressive difficulty scaling
- Performance-optimized spawning system

#### `ObstacleMover.cs`
- Individual obstacle movement logic
- Coin management within obstacle groups
- Activation/deactivation handling

### 🎨 Game Flow

1. **Game Start**: Player spawns at origin, obstacle spawning begins
2. **Gameplay Loop**: 
   - Player moves forward automatically
   - Obstacles spawn ahead with coins attached
   - Player navigates using jump and horizontal movement
   - Score increases with coin collection
   - Difficulty increases over time
3. **Game Over**: Triggered by obstacle collision
4. **Reset**: All systems reset for replay

## 🚀 Features

- **Endless Gameplay**: Procedural obstacle generation
- **Progressive Difficulty**: Speed increases every 5 obstacles
- **Score System**: 10 points per coin collected
- **Object Pooling**: Efficient memory management
- **Physics-Based Movement**: Realistic player controls
- **Visual Effects**: Rotating coins and particle systems
- **Mobile-Ready**: Touch controls supported


## 📱 Build Information

The project includes an APK build (`testBuild.apk`) 

It also include recording folder which have game play recording 
---

**Repository**: [Tawasol_test](https://github.com/shrivaibhav89/Tawasol_test)  