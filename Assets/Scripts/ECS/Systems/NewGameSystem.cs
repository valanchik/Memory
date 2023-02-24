using System;
using System.Linq;
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
                ref var gameComponent = ref CreateGame(systems);
                StartGame(systems,ref gameComponent);
                DisableModalWindow(comp.Target);
            }
        }

        private ref GameComponent CreateGame(IEcsSystems systems)
        {
            var shared = systems.GetShared<ECSSharedData>();
            var gridCards = shared.GridCards;
            gridCards.Clear();
            var gm = systems.GetShared<ECSSharedData>().GameManager;
            var pairs = 0;
            if (gm.CardRowCount>0)
            {
                pairs = (int)(gm.CardColumnCount*gm.CardRowCount)/2;
            }
            else
            {
                var maxRows = GetMaxRows(shared, gm.CardColumnCount);
                if (maxRows*gm.CardColumnCount % 2 !=0 && maxRows>1)
                {
                    maxRows--;
                }
                pairs = (int)(gm.CardColumnCount*maxRows)/2;
            }
            
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
            return ref gameComponent;
        }

        private int GetMaxRows(ECSSharedData shared, int ColCount)
        {
            var list = shared.Game.NewGame(ColCount);
            foreach (var position in list)
            {
                shared.GridCards.AddOneCard(position.Index, position.Value);    
            }

            var card = shared.GridCards.GetCardList().First();
            var maxRows = shared.GridCards.MaxRowsInRect(card, ColCount);
            shared.GridCards.Clear();
            return maxRows;
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