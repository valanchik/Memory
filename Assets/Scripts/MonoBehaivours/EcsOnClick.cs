using Ecs.Components;
using Leopotam.EcsLite;
using UnityEngine;
using UnityEngine.EventSystems;

namespace MonoBehaivours
{
    public enum EcsOnClickType
    {
        newGame,
        Card
    }
    public class EcsOnClick : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField]
        private EcsOnClickType Type;
        private EcsWorld world;
        void Start()
        {
            world = FindObjectOfType<ECSStartup>()._systems.GetWorld();
        }
        void IPointerClickHandler.OnPointerClick (PointerEventData eventData)
        {
            int entity = world.NewEntity ();
            var pool = world.GetPool<ClickActionComponent>();
            pool.Add(entity);
            ref var component = ref pool.Get(entity);
            component.Type = Type;
            component.Target = gameObject;
        }
    }
}
