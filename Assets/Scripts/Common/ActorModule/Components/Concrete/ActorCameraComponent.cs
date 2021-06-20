using UnityEngine;

namespace Common.ActorModule.Components.Concrete
{
    public class ActorCameraComponent :  MonoBehaviour, IActorComponent
    {
        public void Activate()
        {
            Camera = GetComponent<Camera>();
        }

        public void Deactivate()
        {
            Camera = null;
        }
        
        public Camera Camera { get; private set; }
    }
}