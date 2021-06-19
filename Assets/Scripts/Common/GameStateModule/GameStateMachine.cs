using System.Collections.Generic;
using System.Linq;
using Common.GameStateModule.Enums;
using Common.GameStateModule.States.Base;
using Common.GameStateModule.States.Exceptions;

namespace Common.GameStateModule
{
    public class GameStateMachine : IGameStateMachine
    {
        private readonly Dictionary<GameStateId, IGameState> _states;
        
        private GameStateId _currentStateId = GameStateId.Unknown;
        private IGameState _currentState;
        
        public GameStateMachine(IEnumerable<IGameState> gameStates)
        {
            _states = gameStates.ToDictionary(x => x.StateId, x => x);
        }

        public void SetState(GameStateId stateId)
        {
            if (stateId == _currentStateId)
            {
                return;
            }

            if (!_states.TryGetValue(stateId, out var gameState))
            {
                throw new GameStateNullReference($"Game State Machine doesn't contain a {stateId} state");
            }

            if (_currentState != null)
            {
                _currentState.Exit();
            }

            _currentState = gameState;
            _currentState.Enter();
        }
    }
}