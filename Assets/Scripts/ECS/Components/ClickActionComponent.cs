using MonoBehaivours;
using UnityEngine;

namespace Ecs.Components {
    struct ClickActionComponent
    {
        public EcsOnClickType Type;
        public GameObject Target;
    }
}
