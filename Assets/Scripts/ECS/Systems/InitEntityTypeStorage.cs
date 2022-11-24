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
            var ent = systems.GetWorld().NewEntity();
            systems.GetWorld().GetPool<GameComponent>().Add(ent);
            systems.GetWorld().GetPool<LastOpenCardComponent>().Add(ent);
            sharedData.EntityTypeStorage.CreateType(EntityGroup.Common, ent);
        }
    }
}