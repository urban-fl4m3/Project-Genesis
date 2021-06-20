using Common.Generics;

namespace Common.ActorModule.Components
{
    public interface IActorComponent
    {
        void Activate();
        void Deactivate();
    }
}