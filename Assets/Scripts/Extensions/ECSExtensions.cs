using Leopotam.EcsLite;

namespace Extensions
{
    public static class ECSExtensions
    {
        public static bool TryTakeComponentFromPool<T>(this IEcsSystems systems, out   T component) where T: struct
        {
            var world = systems.GetWorld();
            var filter = world.Filter<T>().End();
            foreach (var entity in filter)
            {
                ref var comp = ref world.GetPool<T>().Get(entity);
                component = comp;
                return true;
            }
            component = default;
            return false;
        }
        
        public static ref T TakeComponent<T>(this IEcsSystems systems) where T: struct
        {
            var world = systems.GetWorld();
            var filter = world.Filter<T>().End();
            var pool = world.GetPool<T>();
            foreach (var entity in filter)
            {
                return ref pool.Get(entity);
            }

            return ref pool.Add(world.NewEntity());
        }
        
        public static void RemoveComponent<T>(this IEcsSystems systems) where T : struct
        {
            var world = systems.GetWorld();
            var filter = world.Filter<T> ().End ();
            foreach (int entity in filter)
            {
                world.GetPool<T>().Del(entity);
            }
        }
    }
}