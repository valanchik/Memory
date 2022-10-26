using Ecs.Components;
using Leopotam.EcsLite;

namespace Ecs.Systems
{
    public class RemoveComponentsSystem: IEcsInitSystem, IEcsRunSystem
    {
        private EcsWorld world;
        
        public void Init(IEcsSystems systems)
        {
            world = systems.GetWorld();
        }

        public void Run(IEcsSystems systems)
        {
            RemoveComponent<ClickActionComponent>();
            RemoveComponent<ClickOnCard>();
        }
        private void RemoveComponent<T>() where T : struct
        {
            var filter = world.Filter<T> ().End ();
            foreach (int entity in filter)
            {
                world.GetPool<T>().Del(entity);
            }
        }
    }
}
