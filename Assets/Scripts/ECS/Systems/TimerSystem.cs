using System;
using Ecs;
using Ecs.Components;
using Extensions;
using Leopotam.EcsLite;

namespace ECS.Systems {
    sealed class TimerSystem : IEcsRunSystem {        
        public void Run (IEcsSystems systems)
        {
            ref var gameComponent = ref systems.TakeComponent<GameComponent>(EntityGroup.Common);
            if (gameComponent.Started)
            {
                gameComponent.DeltaTime = gameComponent.StartTime.Subtract(DateTime.Now);
            }
        }
    }
}