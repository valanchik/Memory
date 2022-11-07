using Ecs;
using Ecs.Components;
using Leopotam.EcsLite;

namespace ECS.Systems
{
    public class InitEntityTypeStorage: IEcsInitSystem
    {
        

        public void Init(IEcsSystems systems)
        {
            var sharedData = systems.GetShared<ECSSharedData>();
            sharedData.EntityTypeStorage = new EntityTypeStorage();
            var pool = systems.GetWorld().GetPool<LastOpenCardComponent>();
            var ent = systems.GetWorld().NewEntity();
            pool.Add(ent);
            sharedData.EntityTypeStorage.CreateType(EntityType.Common, ent);
        }
    }
}