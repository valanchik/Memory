using Ecs.Components;
using Extensions;
using Game;
using Leopotam.EcsLite;
using MonoBehaivours;

namespace Ecs.Systems {
    sealed class NewGameSystem :IEcsRunSystem
    {
        public void Run(IEcsSystems systems)
        {
            if (systems.TryTakeComponentFromPool<ClickActionComponent>(out var comp) && comp.Type == EcsOnClickType.NewGame)
            {
                var shared = systems.GetShared<ECSSharedData>();
                var gridCards = shared.GridCards;
                gridCards.Clear();
                var pairs = 6;
                var list = shared.Game.NewGame(pairs);
                ref var gameComponent = ref systems.TakeComponent<GameComponent>(EntityGroup.Common);
                gameComponent.Pairs = shared.Game.Pairs;
                gameComponent.OpenedPairs = 0;
                foreach (var position in list)
                {
                    gridCards.AddOneCard(position.Index, position.Value);    
                }
            }
        }
    }
}