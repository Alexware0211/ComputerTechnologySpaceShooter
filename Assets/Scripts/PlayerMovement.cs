using Unity.Entities;
using Unity.Burst;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

[UpdateBefore(typeof(TransformSystemGroup))]
public partial struct PlayerMovement : ISystem
{
    private const float ScreenWidth = 9.1f;
    private const float ScreenHeight = 5.25f;

    [BurstCompile]
    public void OnUpdate(ref SystemState state)
    {
        Config config = SystemAPI.GetSingleton<Config>();
        Player player = SystemAPI.GetSingleton<Player>();
        var deltaTime = SystemAPI.Time.DeltaTime;
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        RefRW<LocalTransform> playerTransform = SystemAPI.GetComponentRW<LocalTransform>(player.Entity);
        
        if (horizontal != 0)
        {
            RotatePlayer(playerTransform, config, deltaTime, horizontal);
        }

        if (vertical != 0)
        {
            MovePlayer(playerTransform, config, deltaTime, vertical);
        } 

        if (playerTransform.ValueRO.Position.y < -ScreenHeight)
        {
            playerTransform.ValueRW.Position = new float3(playerTransform.ValueRO.Position.x, ScreenHeight, 0);
        }  
        else if (playerTransform.ValueRO.Position.y > ScreenHeight)
        {
            playerTransform.ValueRW.Position = new float3(playerTransform.ValueRO.Position.x, -ScreenHeight, 0);
        }   
        else if (playerTransform.ValueRO.Position.x < -ScreenWidth)
        {
            playerTransform.ValueRW.Position = new float3(ScreenWidth, playerTransform.ValueRO.Position.y, 0);
        }
        else if (playerTransform.ValueRO.Position.x > ScreenWidth)
        {
            playerTransform.ValueRW.Position = new float3(-ScreenWidth, playerTransform.ValueRO.Position.y, 0);
        }   
    }

    [BurstCompile]
    public void OnCreate(ref SystemState state)
    {
        state.RequireForUpdate<Config>();
        state.RequireForUpdate<Player>();
    }
    
    private static void RotatePlayer(RefRW<LocalTransform> playerTransform, Config config, float deltaTime, float horizontal)
    {
        quaternion currentRotation = playerTransform.ValueRO.Rotation;
        float rotation = config.PlayerRotationSpeed * deltaTime * -horizontal;

        playerTransform.ValueRW.Rotation = math.mul(currentRotation, quaternion.RotateZ(rotation));
    }
    private static void MovePlayer(RefRW<LocalTransform> playerTransform, Config config, float deltaTime, float vertical)
    {
        float3 direction = math.mul(playerTransform.ValueRO.Rotation, new float3(0, 1, 0));
        playerTransform.ValueRW.Position += direction * config.PlayerSpeed * deltaTime * vertical;
    }

}