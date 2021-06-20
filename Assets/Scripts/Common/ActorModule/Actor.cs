using Common.ActorModule.Components;
using Common.Generics;
using UnityEngine;

namespace Common.ActorModule
{
    public class Actor : MonoBehaviour, IActor
    {
        public GameObject Object => gameObject;
        
        private readonly TypeContainer _container = new TypeContainer();
        
        public void Activate()
        {
            var components = GetComponents<IActorComponent>();
            foreach (var actorComponent in components)
            {
                _container.Add(actorComponent.GetType(), actorComponent);
                actorComponent.Activate();
            }
        }

        public void Deactivate()
        {
            var components = _container.GetList<IActorComponent>();
            foreach (var actorComponent in components)
            {
                actorComponent.Deactivate();
            }
        }

        public T GetActorComponent<T>() where T : class, IActorComponent
        {
            return _container.Resolve<T>(); 
        }
    }
}