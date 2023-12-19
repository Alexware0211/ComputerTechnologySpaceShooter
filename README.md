# Computer Technology Space Shooter using DOTS
This purpose of this assignment was to make a space shooter in Unity utilized unitys DOTS system to optimize performance. DOTS brings a lot of new features to make use of in more entity heavy games such as Vampire survivor where you need to manage 100 or even 1000 enemies on the screen without affecting performance, to do that you need to utilize the new Job System, Burst Compiler and ECS. These tools help give more control over CPU usage and making more performance critical code.


# Controls
- A & D to turn ship.
- W & S to move.
- Space to shoot.

# Performance

I made two different versions, One is this [link](https://github.com/Alexware0211/NoDOTSSpaceShooterr) which uses no optimization. In that version once I spawn 25k asteroids the game initialy freezes then plays at 3-6 FPS.

![image](https://github.com/Alexware0211/ComputerTechnologySpaceShooter/assets/113015594/fdecb5f3-56ba-435f-956d-4c02efe4f16e)

On this version however which utalizes dots I get no freeze at the spawning and performance seems fine as I can do 40 FPS during 25k asteroids.

![image](https://github.com/Alexware0211/ComputerTechnologySpaceShooter/assets/113015594/c1aecec0-2ab8-4ce8-bca4-1e85705e9673)

# Optimization

In order to optimize the project to save as much FPS as possible and increase the amount of asteroids if required I made use of ECS (Entity Componenet System) for my spawning, movement and shooting scripts. Thanks to the Job System and Burst Compiler I can spawn in 25k asteroids without any major cost of performance, that just goes to show how powerful ECS is, without it I wouldn't have been able to spawn in 25k asteroids as fluently.

# Specs

This was tested on the school Computer which is all things considers a rather good computer, the specs are as follows:
- CPU 11th Gen Intel Core i5-11600k @ 3.90 GHz
- GPU NVIDIA GeForce RTX 3060
