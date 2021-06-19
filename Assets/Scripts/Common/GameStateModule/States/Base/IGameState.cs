using Common.GameStateModule.Enums;

namespace Common.GameStateModule.States.Base
{
    public interface IGameState
    {
        GameStateId StateId { get; }
        
        void Enter();
        void Exit();
    }
}