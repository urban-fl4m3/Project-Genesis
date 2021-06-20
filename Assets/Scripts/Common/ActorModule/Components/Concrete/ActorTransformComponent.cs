using UnityEngine;

namespace Common.ActorModule.Components.Concrete
{
    public class ActorTransformComponent : MonoBehaviour, IActorComponent
    {
        public void Activate()
        {
            Transform = GetComponent<Transform>();
        }

        public void Deactivate()
        {
            Transform = null;
        }

        public Transform Transform { get; private set; }
        public Vector3 Position => transform.position;
    }
}