using Ecs.Components;
using Extensions;
using Leopotam.EcsLite;

namespace ECS.Systems {
    sealed class RotatedCardSystem : IEcsRunSystem {        
        public void Run (IEcsSystems systems) {
            if (systems.TryTakeOnComponentFromPool<RotatedCardComponent>(out var comp))
            {
                comp.Card.GetComponent<Card>().Toggle(() =>
                {
                    
                });
            }
        }
    }
}