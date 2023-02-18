using Ecs;
using Ecs.Components;
using Extensions;
using Leopotam.EcsLite;
using UnityEditor;
using UnityEngine;

namespace ECS.Systems {
    sealed class CheckOpenedCardSystem : IEcsRunSystem {        
    public void Run(IEcsSystems systems) {
        var world = systems.GetWorld();
        
        var filter = world.Filter<LastOpenCardComponent>().Inc<OpenedCardComponent>().End();
        
        foreach (var entity in filter) {
            ref var lastOpenCardComponent = ref world.GetPool<LastOpenCardComponent>().Get(entity);
            ref var openedCardComponent = ref world.GetPool<OpenedCardComponent>().Get(entity);

            var lastOpenedCard = lastOpenCardComponent.Card; 
            var openedCard = openedCardComponent.Card;
            
            if (lastOpenedCard != null) {
                if (lastOpenedCard.Value == openedCard.Value) {
                    lastOpenedCard.CanRotate = false;
                    openedCard.CanRotate = false;
                    
                    ref var gameComponent = ref systems.TakeComponent<GameComponent>(EntityGroup.Common);
                    gameComponent.OpenedPairs++;
                    
                    if (gameComponent.Pairs == gameComponent.OpenedPairs) {
                        systems.TakeComponent<EndGameComponent>(EntityGroup.Common);
                    }
                }
                else if (lastOpenedCard.CanRotate) {
                    lastOpenedCard.Hide();
                    IncrementSteps(systems);
                }
                lastOpenCardComponent.Card = openedCard;
            }
            else {
                ref var newLastOpenCardComponent = ref systems.TakeComponent<LastOpenCardComponent>(EntityGroup.Common);
                newLastOpenCardComponent.Card = openedCard;
            }
        }
    }

    public void IncrementSteps(IEcsSystems systems)
    {
        ref var gameComponent = ref systems.TakeComponent<GameComponent>(EntityGroup.Common);
        gameComponent.Steps++;
    }
}

}