using System;
using Unity.Collections;
using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

[AlwaysUpdateSystem]
public class MovementSystem : JobComponentSystem
{
    private struct MovementJob : IJobForEach<Translation, Rotation, MoveComponent>
    {

        public float dt;

        public void Execute(ref Translation translatrion, [ReadOnly] ref Rotation rotation, [ReadOnly] ref MoveComponent speed)
        {
            translatrion.Value += math.forward(rotation.Value) * dt * speed.moveSpeed;
        }
    }

    protected override JobHandle OnUpdate(JobHandle inputDeps)
    {
        var job = new MovementJob
        {
            dt = Time.deltaTime
        };

        return job.Schedule(this, inputDeps);
    }
}
