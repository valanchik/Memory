using Ecs.Components;
using Extensions;
using Leopotam.EcsLite;

namespace Ecs.Systems
{
    public class RemoveComponentsSystem: IEcsRunSystem
    {
        public void Run(IEcsSystems systems)
        {
            systems.RemoveComponent<ClickActionComponent>();
            systems.RemoveComponent<ClickOnCard>();
            systems.RemoveComponent<OpenedCardComponent>();
            systems.RemoveComponent<EndGameComponent>();
        }
    }
}
