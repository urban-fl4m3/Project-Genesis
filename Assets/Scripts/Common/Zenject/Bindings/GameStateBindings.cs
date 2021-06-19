using Common.GameStateModule;
using Common.GameStateModule.Enums;
using Common.GameStateModule.States;
using Common.GameStateModule.States.Battle;
using Common.GameStateModule.States.Menu;
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

            container.Bind<IConcreteState<ApplicationState>>().To<MenuConcreteState>().AsTransient();
            container.Bind<IConcreteState<ApplicationState>>().To<GameConcreteState>().AsTransient();
        }
    }
}