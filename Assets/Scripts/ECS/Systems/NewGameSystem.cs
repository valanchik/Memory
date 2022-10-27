using Ecs.Components;
using Leopotam.EcsLite;
using MonoBehaivours;

namespace Ecs.Systems {
    sealed class NewGameSystem : IEcsInitSystem, IEcsRunSystem
    {
        private EcsWorld world;
        public void Init(IEcsSystems systems)
        {
            world = systems.GetWorld ();
        }
        public void Run(IEcsSystems systems)
        {
            var filter = world.Filter<ClickActionComponent>().End ();
            var pool = world.GetPool<ClickActionComponent>();
            foreach (int entity in filter)
            {
                ref var comp = ref pool.Get(entity);
                if (comp.Type == EcsOnClickType.newGame)
                {
                    var shared = systems.GetShared<SharedData>();
                    shared.Game.NewGame(12);
                    shared.GridCards.AddOneCard();
                }
            }
            
        }
    }
}