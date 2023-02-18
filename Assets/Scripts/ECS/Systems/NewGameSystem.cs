using System;
using Ecs.Components;
using Extensions;
using Game;
using Leopotam.EcsLite;
using MonoBehaivours;
using UnityEngine;

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
                var gm = systems.GetShared<ECSSharedData>().GameManager;
                var pairs = (int)(gm.CardColumnCount*gm.CardRowCount)/2;
                gridCards.SetColumnCount(gm.CardColumnCount);
                var list = shared.Game.NewGame(pairs);
                ref var gameComponent = ref systems.TakeComponent<GameComponent>(EntityGroup.Common);
                gameComponent.Pairs = shared.Game.Pairs;
                gameComponent.OpenedPairs = 0;
                foreach (var position in list)
                {
                    gridCards.AddOneCard(position.Index, position.Value);    
                }
                gridCards.AutoGridSize();
                StartGame(systems,ref gameComponent);
                DisableModalWindow(comp.Target);
            }
        }

        private void StartGame(IEcsSystems systems, ref GameComponent comp)
        {
            comp.StartTime = DateTime.Now;
            comp.Started = true;
            comp.Steps = 0;
            comp.BadSteps = 0;
            comp.RecordPoints = 0;
        }

        private void DisableModalWindow(GameObject target)
        {
            target.GetComponentInParent<Canvas>().gameObject.SetActive(false);
        }
    }
    
}