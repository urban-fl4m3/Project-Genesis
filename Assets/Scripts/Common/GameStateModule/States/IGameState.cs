using Common.GameStateModule.Enums;

namespace Common.GameStateModule.States
{
    public interface IGameState
    {
        GameStateId StateId { get; }
        
        void Enter();
        void Exit();
    }
}