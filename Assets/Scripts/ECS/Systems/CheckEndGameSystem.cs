using Ecs.Components;
using Leopotam.EcsLite;
using UnityEngine;

namespace ECS.Systems {
    sealed class CheckEndGameSystem : IEcsRunSystem {        
        public void Run (IEcsSystems systems) {
            var world = systems.GetWorld();
            var filter = world.Filter<EndGameComponent>().End();
            foreach (var entity in filter)
            {
                Debug.Log($"EndGame");    
            }
        }
    }
}