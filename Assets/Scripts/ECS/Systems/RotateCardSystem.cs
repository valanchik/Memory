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
                comp.Target.GetComponent<Card>()?.Toggle(() =>
                {
                    Debug.Log("EndRotation");
                });
            }
        }
    }
}