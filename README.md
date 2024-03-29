# Computer Technology Space Shooter using DOTS
This purpose of this assignment was to make a space shooter in Unity utilized unitys DOTS system to optimize performance. DOTS brings a lot of new features to make use of in more entity heavy games such as Vampire survivor where you need to manage 100 or even 1000 enemies on the screen without affecting performance, to do that you need to utilize the new Job System, Burst Compiler and ECS. These tools help give more control over CPU usage and making more performance critical code.


# Controls
- A & D to turn ship.
- W & S to move.
- Space to shoot.

# Performance

I made two different versions, One which utilizes OOP (Object Oriented Programming). As you can see in the image below the frames were horrendous after 25k asteroids.

![image](https://github.com/Alexware0211/ComputerTechnologySpaceShooter/assets/113015594/fdecb5f3-56ba-435f-956d-4c02efe4f16e)

On this version utilizing ECS I increased performance massively, as seen below at 25k asteroids I still get 40 fps which is a acceptable amount.

![image](https://github.com/Alexware0211/ComputerTechnologySpaceShooter/assets/113015594/c1aecec0-2ab8-4ce8-bca4-1e85705e9673)

# Optimization

For this project's optimization, I used ECS fo, Burst Compiler and the Jobs System. Utilizing object-oriented programming, I wouldn't possibly accomplish my 30 fps aim if 30,000 asteroids spawned simultaneously. Because of this, DOTS is incredibly strong and enables my game to have a large number of objects generated in the scene simultaneously without sacrificing performance. One example of the improvement was the Asteroids Movement, Before any optimization the movement took way to long. In order to optimize I changed it from the following [Script](https://github.com/Alexware0211/NoDOTSSpaceShooterr/blob/main/Assets/Scripts/Asteroid.cs) into this improved [Script](https://github.com/Alexware0211/ComputerTechnologySpaceShooter/blob/main/Assets/Scripts/AsteroidMove.cs). As we can see in the images below everything improved but most important was the process per frame.

Unoptimized

![Unoptimized Asteroid Movement](https://github.com/Alexware0211/ComputerTechnologySpaceShooter/assets/113015594/f823dbd7-15ba-44a0-b1ee-7d8349186cda)

Optimized

![Optimized Asteroid Movement](https://github.com/Alexware0211/ComputerTechnologySpaceShooter/assets/113015594/c21fcba5-420e-4757-9505-624173f811e5)

# Specs

- 16 GB RAM
- CPU 11th Gen Intel Core i5-11600k @ 3.90 GHz
- GPU NVIDIA GeForce RTX 3060
