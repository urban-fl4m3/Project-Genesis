using Common.GameStateModule;
using Common.GameStateModule.States;
using Common.GameStateModule.States.Base;
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

            container.Bind<IGameState>().To<MenuGameState>().AsTransient();
            container.Bind<IGameState>().To<BattleGameState>().AsTransient();
        }
    }
}