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
            CheckRecordPointsAndSave(systems, ref gameComponent);
        }

        public void CheckRecordPointsAndSave(IEcsSystems systems, ref GameComponent gameComponent)
        {
            var storege = systems.GetShared<ECSSharedData>().Storage;
            if (storege.GetPoins()<=gameComponent.RecordPoints)
            {
                storege.SavePoints(gameComponent.RecordPoints);
            }
        }
    }
}