using System;
using Ecs;
using Ecs.Components;
using Leopotam.EcsLite;
using Extensions;

namespace ECS.Systems {
    sealed class CalculationPointSystem : IEcsRunSystem
    {
        public void Run(IEcsSystems systems)
        {
            ref var gameComponent = ref systems.TakeComponent<GameComponent>(EntityGroup.Common);
            if (gameComponent.Started)
            {
                if (gameComponent.Pairs!=0 && gameComponent.Steps!=0)
                {
                    gameComponent.RecordPoints = gameComponent.Pairs / gameComponent.Steps;                    
                }

                RenderInfoPanel(systems, ref gameComponent);
            }
        }

        private void RenderInfoPanel(IEcsSystems systems, ref GameComponent gameComponent)
        {
            var infoPanel = systems.GetShared<ECSSharedData>().InfoPanel;
            infoPanel.SetTime(gameComponent.DeltaTime);
            infoPanel.SetSteps(gameComponent.Steps);
            infoPanel.SetPoints(gameComponent.RecordPoints);
        }
    }
}