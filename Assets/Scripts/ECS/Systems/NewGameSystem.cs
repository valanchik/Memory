using Ecs.Components;
using Leopotam.EcsLite;

namespace Ecs.Systems {
    sealed class NewGameSystem : IEcsInitSystem, IEcsRunSystem
    {
        private EcsWorld world;
        public void Init(IEcsSystems systems)
        {
            world = systems.GetWorld ();
            int entity = world.NewEntity ();
            world.GetPool<NewGameComponent>().Add(entity);
        }
        public void Run(IEcsSystems systems)
        {
            var filter = world.Filter<NewGameComponent> ().End ();
            foreach (int entity in filter)
            {
                var pool = world.GetPool<NewGameComponent>();
                ref var weapon = ref pool.Get(entity);
                var shared = systems.GetShared<SharedData>();
                shared.Game.NewGame(12);
                shared.GridCards.AddOneCard();
                pool.Del(entity);
            }
            
        }
    }
}