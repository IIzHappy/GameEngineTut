Rachel Dong 100963735

2D Shooter
2D Shooter is just an infinite 2D shooter with enemies spawning around you that you have to shoot to defeat

A diagram (ie: Flowchart/Pseudocode/Mermaid/UML or similar) explaining your use of the Factory or Singleton Design Pattern
Player Singleton
  Only one instance of player
  Player position easily accessible by enemies

What element of your game adopts the chosen pattern?
The game uses multiple Singletons for the player controller and bullets/enemy managers to make all relevent data easily accesible
There is a Factory built in for enemy spawning, but there is currently just one basic enemy type

Why is this pattern a good choice for the associated functionality?
Making the player controller a Singleton is really important because most of the game relies on the information stored in the player controller so making it a Singleton allows everything to easily access it
