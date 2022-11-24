using System;
using Ecs;
using Ecs.Components;
using Extensions;
using Leopotam.EcsLite;
using MonoBehaivours;
using UnityEngine;

namespace ECS.Systems {
    sealed class RotateCardSystem : IEcsRunSystem {        
        public void Run (IEcsSystems systems)
        {
            if (systems.TryTakeComponentFromPool<ClickActionComponent>(out var clickActionComponent) && clickActionComponent.Type == EcsOnClickType.Card)
            {
                var card = clickActionComponent.Target.GetComponent<Card>();
                
                if (!card.IsOpen)
                {
                    card.Show(() =>
                    {
                        ref var takeComponent = ref systems.TakeComponent<OpenedCardComponent>(EntityGroup.Common);
                        takeComponent.Card = card;
                    });
                }
            }
        }
    }
}