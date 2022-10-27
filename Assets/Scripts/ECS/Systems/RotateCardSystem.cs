using Ecs.Components;
using Leopotam.EcsLite;
using MonoBehaivours;

namespace ECS.Systems {
    sealed class RotateCardSystem : IEcsRunSystem {        
        public void Run (IEcsSystems systems)
        {
            var world = systems.GetWorld();
            var filter = world.Filter<ClickActionComponent>().End();
            foreach (var entity in filter)
            {
                ref var comp = ref world.GetPool<ClickActionComponent>().Get(entity);
                if (comp.Type == EcsOnClickType.Card)
                {
                    comp.Target.GetComponent<Card>()?.Toggle();    
                }
                
            }
        }
    }
}