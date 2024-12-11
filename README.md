# Tethered Onslaught

## Description

Tethered Onslaught is a 2D game built with Unity where a duo of players are physically linked by an electric tether in a chaotic battle arena. They have to fight endless waves of enemies for survival using the tether.

### Main Features

- **Ability Sharing**: The tether allows ability sharing, such as when a player blinks, the other player also blinks in sync.
- **Shield Creation**: The tether creates a shield when 2 players move in unison next to each other.
- **Electrocution**: If players are far from each other a certain range, they can use the tether to electrocute the enemies.
- **Combo Bonuses**: Players must coordinate to maximize combo bonuses by chaining kills. Combos can be used if 2 players do a set of actions at the same time.
- **Tether Customization**: The tether is customizable with mystery boxes (e.g., turning it into a laser whip or a stun trap).
- **Leaderboard**: There's a leaderboard for longest survival time and highest combo chains.
- **Multiple Settings**: The game can be in multiple settings based on the rounds, such as frost, retro, etc.
- **Physics Rules**: The tether now has physics rules implemented using `SpringJoint2D` components to simulate realistic tether behavior and interactions with players and the environment.

## Build and Run

To build and run the game using Unity:

1. Clone the repository:
   ```
   git clone https://github.com/lmBored/Tethered-Onslaught.git
   ```
2. Open the project in Unity.
3. Build the game by selecting `File > Build Settings` and then clicking `Build`.
4. Run the game by opening the built executable.

## TODO

+ Develop to 3D.

## Contributing

We welcome contributions to the project! To contribute:

1. Fork the repository.
2. Create a new branch for your feature or bugfix.
3. Make your changes and commit them with clear and descriptive messages.
4. Push your changes to your forked repository.
5. Create a pull request to the main repository with a description of your changes.

Thank you for contributing!
