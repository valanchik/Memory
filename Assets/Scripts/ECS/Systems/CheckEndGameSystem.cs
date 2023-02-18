using Ecs;
using Ecs.Components;
using Extensions;
using Leopotam.EcsLite;
using UnityEngine;

namespace ECS.Systems {
    sealed class CheckEndGameSystem : IEcsRunSystem {        
        public void Run (IEcsSystems systems)
        {
            systems.TakeComponents<EndGameComponent>( component =>
            {
                EndingGame(systems);
            });
        }
        private void EndingGame(IEcsSystems systems)
        {
            ref var gameComponent = ref systems.TakeComponent<GameComponent>(EntityGroup.Common);
            gameComponent.Started = false;
            systems.GetShared<ECSSharedData>().ModalCanvas.SetActive(true);
            CalculateGamePoints(systems, ref gameComponent);
        }

        public void CalculateGamePoints(IEcsSystems systems, ref GameComponent gameComponent)
        {
            
        }
    }
}