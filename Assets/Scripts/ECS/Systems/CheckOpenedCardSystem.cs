using Ecs;
using Ecs.Components;
using Extensions;
using Leopotam.EcsLite;
using UnityEditor;
using UnityEngine;

namespace ECS.Systems {
    sealed class CheckOpenedCardSystem : IEcsRunSystem {        
        public void Run (IEcsSystems systems)
        {
            if (systems.TryTakeComponentFromPool<OpenedCardComponent>(out var  comp))
            {
                var card = comp.Card;
                var world = systems.GetWorld();
                var filter = world.Filter<LastOpenCardComponent>().End();
                foreach (var entity in filter)
                {
                    ref var lastOpenCardComponent = ref world.GetPool<LastOpenCardComponent>().Get(entity);
                    if (lastOpenCardComponent.Card.Value == card.Value)
                    {
                        lastOpenCardComponent.Card.CanRotate = false;
                        card.CanRotate = false;
                    }
                    else if(lastOpenCardComponent.Card.CanRotate)  
                    {
                        
                        lastOpenCardComponent.Card.Hide();
                    }
                    lastOpenCardComponent.Card = card;
                    return;
                }
                ref var newLastOpenCardComponent = ref systems.TakeComponent<LastOpenCardComponent>();
                newLastOpenCardComponent.Card = card;
            }
        }
    }
}