using Common.GameStateModule.Enums;

namespace Common.GameStateModule
{
    public interface IGameStateMachine
    {
        void SetState(ApplicationState state);
    }
}