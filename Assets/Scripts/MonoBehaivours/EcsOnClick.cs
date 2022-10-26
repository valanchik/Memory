using Ecs.Components;
using Leopotam.EcsLite;
using UnityEngine;
using UnityEngine.EventSystems;

namespace MonoBehaivours
{
    public class EcsOnClick : MonoBehaviour, IPointerClickHandler
    {
        private EcsWorld world;
        void Start()
        {
            var obj = FindObjectOfType<ECSStartup>();
            world = FindObjectOfType<ECSStartup>()._systems.GetWorld();
        }
        void IPointerClickHandler.OnPointerClick (PointerEventData eventData)
        {
            int entity = world.NewEntity ();
            var pool = world.GetPool<ClickActionComponent>();
            pool.Add(entity);
            ref var component = ref pool.Get(entity);
            component.Target = gameObject;
        }
    }
}
