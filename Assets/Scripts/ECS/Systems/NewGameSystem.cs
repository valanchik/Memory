using Ecs.Components;
using Extensions;
using Leopotam.EcsLite;
using MonoBehaivours;

namespace Ecs.Systems {
    sealed class NewGameSystem :IEcsRunSystem
    {
        public void Run(IEcsSystems systems)
        {
            if (systems.TryTakeOnComponentFromPool<ClickActionComponent>(out var comp) && comp.Type == EcsOnClickType.newGame)
            {
                var shared = systems.GetShared<SharedData>();
                shared.Game.NewGame(12);
                shared.GridCards.AddOneCard();
            }
            
        }
    }
}