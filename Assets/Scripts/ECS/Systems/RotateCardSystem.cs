using Ecs.Components;
using Extensions;
using Leopotam.EcsLite;
using MonoBehaivours;
using UnityEngine;

namespace ECS.Systems {
    sealed class RotateCardSystem : IEcsRunSystem {        
        public void Run (IEcsSystems systems)
        {
            if (systems.TryTakeOnComponentFromPool<ClickActionComponent>(out var comp) && comp.Type == EcsOnClickType.Card)
            {
                var card = comp.Target.GetComponent<Card>();
                if (card!=null && card.CanRotate)
                {
                    
                    card.Toggle(() =>
                    {
                        ref var takeComponent = ref  systems.TakeComponent<RotatedCardComponent>();
                        takeComponent.Card = card;
                    });
                }
            }
        }
    }
}