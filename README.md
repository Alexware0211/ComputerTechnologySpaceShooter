# Computer Technology Space Shooter using DOTS
This purpose of this assignment was to make a space shooter in Unity utilized unitys DOTS system to optimize performance. DOTS brings a lot of new features to make use of in more entity heavy games such as Vampire survivor where you need to manage 100 or even 1000 enemies on the screen without affecting performance, to do that you need to utilize the new Job System, Burst Compiler and ECS. These tools help give more control over CPU usage and making more performance critical code.


# Controls
- A & D to turn ship.
- W & S to move.
- Space to shoot.

# Performance

I made two different versions, One which is this link  which uses no optimization. In that version once I spawn 25k asteroids the game initialy freezes then plays at 3-6 FPS.

![image](https://github.com/Alexware0211/ComputerTechnologySpaceShooter/assets/113015594/fdecb5f3-56ba-435f-956d-4c02efe4f16e)

On this version however which utalizes dots I get no freeze at the spawning and performance seems fine as I can do 40 FPS during 25k asteroids.

![image](https://github.com/Alexware0211/ComputerTechnologySpaceShooter/assets/113015594/c1aecec0-2ab8-4ce8-bca4-1e85705e9673)


