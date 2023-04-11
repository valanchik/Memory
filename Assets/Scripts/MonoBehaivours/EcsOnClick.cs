using Ecs;
using Ecs.Components;
using Leopotam.EcsLite;
using UnityEngine;
using UnityEngine.EventSystems;

namespace MonoBehaivours
{
    public enum EcsOnClickType
    {
        NewGame,
        Card
    }
    public class EcsOnClick : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField]
        private EcsOnClickType Type;
        private EcsWorld world;
        private IEcsSystems systems;
        private EntityTypeStorage entityTypeStorage;
        void Start()
        {
            systems = FindObjectOfType<ECSStartup>()._systems; 
            world = systems.GetWorld();
            entityTypeStorage = systems.GetShared<ECSSharedData>().EntityTypeStorage;
        }
        void IPointerClickHandler.OnPointerClick (PointerEventData eventData)
        {
            int entity = entityTypeStorage.GetEntityByType(EntityGroup.Common);
            var pool = world.GetPool<ClickActionComponent>();
            pool.Add(entity);
            ref var component = ref pool.Get(entity);
            component.Type = Type;
            component.Target = gameObject;
        }
    }
}
