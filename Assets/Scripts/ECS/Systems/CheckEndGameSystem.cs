using Ecs;
using Ecs.Components;
using Extensions;
using Game;
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
            SaveRecod(systems, ref gameComponent);
        }

        public void SaveRecod(IEcsSystems systems, ref GameComponent gameComponent)
        {
            var storege = systems.GetShared<ECSSharedData>().Storage;
            var result = new GameResult()
            {
                Time = gameComponent.DeltaTime,
                Steps = gameComponent.Steps,
                ColumnCount = gameComponent.ColumCount
            };
            if (storege.TrySaveGameResult(result))
            {
                Debug.Log($"Рекорд: {result}");    
            }
        }
    }
}