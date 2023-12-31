using System.Linq;
using Unity.Entities;
using Unity.Burst;
using Unity.Transforms;
using Unity.Mathematics;
using Random = UnityEngine.Random;

public partial struct AsteroidSpawner : ISystem
{
    private const float ScreenHeight = 5.20f;
    private float _spawnCooldown;
    private bool _spawnTop;
    private bool _spawnLeft;
    private int _asteroidCount;
    private int _wave;
    [BurstCompile]
    public void OnCreate(ref SystemState state)
    {
        state.RequireForUpdate<Config>();
    }

    [BurstCompile]
    public void OnUpdate(ref SystemState state)
    {
        foreach (var (asteroidTransform, asteroidPrefab) in SystemAPI.Query<RefRW<LocalTransform>>().WithAll<Asteroid>()
                     .WithEntityAccess())
        {
            return;
        }
        
        var config = SystemAPI.GetSingleton<Config>();
        var dt = SystemAPI.Time.DeltaTime;
        
        _spawnCooldown += dt;

        if (_spawnCooldown < config.AsteroidSpawnRate) return;
        
        _wave++;
        
        int spawnAmount = config.AsteroidSpawnAmount * _wave + _wave*_wave;
        
        for (int i = 0; i < spawnAmount; i++)
        {
            Entity asteroid = state.EntityManager.Instantiate(config.AsteroidPrefab);
            float yPos;
            float3 direction;
            
            if (_spawnTop)
            {
                yPos = ScreenHeight;
                direction = math.normalize(new float3(Random.Range(-0.9f, 0.9f), Random.Range(-0.1f, -1.0f), 0));
            }
            else
            {
                yPos = -ScreenHeight;
                direction = math.normalize(new float3(Random.Range(-0.9f, 0.9f), Random.Range(0.1f, 1.0f), 0));
            }
            
            float xPos = Random.Range(-8.0f, 8.0f);

            _spawnTop = !_spawnTop;
            SystemAPI.GetComponentRW<LocalTransform>(asteroid).ValueRW.Position = new float3(xPos, yPos, 0);
            SystemAPI.GetComponentRW<Asteroid>(asteroid).ValueRW.Direction = direction;
        }
        _spawnCooldown = 0;
    }
}
