using Common.GameStateModule;
using Zenject;

namespace Common.Zenject.Bindings
{
    public class GameStateBindings
    {
        public static void Bind(DiContainer container)
        {
            container
                .Bind<IGameStateMachine>()
                .To<GameStateMachine>()
                .AsSingle();
        }
    }
}