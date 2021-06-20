using UnityEngine;

namespace Common.ActorModule.Components
{
    public interface IActor
    {
        GameObject Object { get; }
        
        T GetActorComponent<T>() where T : class, IActorComponent;
        
        void Activate();
        void Deactivate();
    }
}