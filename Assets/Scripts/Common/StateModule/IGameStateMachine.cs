using Common.GameModule.Enums;

namespace Common.StateModule
{
    public interface IGameStateMachine
    {
        void SetState(ApplicationState state);
    }
}