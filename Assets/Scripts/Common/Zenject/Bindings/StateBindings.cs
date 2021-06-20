using Common.GameModule.Battle;
using Common.GameModule.Enums;
using Common.GameStateModule.States.Menu;
using Common.StateModule;
using Common.StateModule.States;
using Zenject;

namespace Common.Zenject.Bindings
{
    public class StateBindings
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