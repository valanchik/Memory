using Game;
using MonoBehaivours;
using UnityEngine;

namespace Ecs
{
    public class ECSSharedData
    {
        public MemoryGame Game;
        public GridCards GridCards;
        public GameObject ModalCanvas;
        public GameManager GameManager;
        public EntityTypeStorage EntityTypeStorage;
        public InfoPanel InfoPanel;
    }
}