using Common.GameModule.Enums;
using Common.StateModule.States;

namespace Common.GameStateModule.States.Menu
{
    public class MenuConcreteState : IConcreteState<ApplicationState>
    {
        public ApplicationState State => ApplicationState.Menu;

        public MenuConcreteState()
        {
            
        }
        
        public void Enter()
        {
            
        }

        public void Exit()
        {
            
        }
    }
}