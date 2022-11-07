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
                var world = systems.GetWorld();
                var filter = world.Filter<LastOpenCardComponent>().Inc<OpenedCardComponent>().End();
                foreach (var entity in filter)
                {
                    ref var lastOpenCardComponent = ref world.GetPool<LastOpenCardComponent>().Get(entity);
                    ref var openedCardComponent = ref world.GetPool<OpenedCardComponent>().Get(entity);
                    var card = openedCardComponent.Card;
                    if (lastOpenCardComponent.Card!=null)
                    {
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
                    else
                    {
                        ref var newLastOpenCardComponent = ref systems.TakeComponent<LastOpenCardComponent>(EntityType.Common);
                        newLastOpenCardComponent.Card = card;
                    }
                }
            }
    }
}