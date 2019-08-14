/* 
    ------------------- Code Monkey -------------------

    Thank you for downloading this package
    I hope you find it useful in your projects
    If you have any questions let me know
    Cheers!

               unitycodemonkey.com
    --------------------------------------------------
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Transforms;
using Unity.Collections;
using Unity.Rendering;
using Unity.Mathematics;

public class Testing : MonoBehaviour {

    [SerializeField] private Mesh mesh;
    [SerializeField] private Material material;

    private void Start() {
        EntityManager entityManager = World.Active.EntityManager;

        EntityArchetype entityArchetype = entityManager.CreateArchetype(
            typeof(LevelComponent),
            typeof(Translation),
            typeof(RenderMesh),
            typeof(LocalToWorld),
            typeof(MoveComponent)
        );
        NativeArray<Entity> entityArray = new NativeArray<Entity>(1, Allocator.Temp);
        entityManager.CreateEntity(entityArchetype, entityArray);

        for (int i = 0; i < entityArray.Length; i++) {
            Entity entity = entityArray[i];

            entityManager.SetComponentData(entity, 
                new MoveComponent { 
                    moveSpeed = UnityEngine.Random.Range(1f, 2f) 
                }
            );
            entityManager.SetComponentData(entity, 
                new Translation { 
                    Value = new float3(UnityEngine.Random.Range(-8, 8f), UnityEngine.Random.Range(-5, 5f), 0) 
                }
            );

            entityManager.SetSharedComponentData(entity, new RenderMesh {
                mesh = mesh,
                material = material,
            });
        }

        entityArray.Dispose();

    }

}
